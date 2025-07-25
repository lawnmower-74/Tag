using UnityEngine;

/// <summary>Playerの発見状態ごとで徘徊／追跡を振り分ける</summary>
public class TaggerController : MonoBehaviour
{
    public TaggerVision TaggerVision;
    public AudioClip FindSE;

    private WanderField _wanderField;
    private ChasePlayer _chasePlayer;
    private Transform _targetTransform;
    private Animator _animator;
    private AudioSource _audioSource;
    private bool _playedFindSE = false;
    private bool _isChasing = false;

    void Awake()
    {
        _wanderField = GetComponent<WanderField>();
        _chasePlayer = GetComponent<ChasePlayer>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // 初期状態は徘徊
        SetStateWandering();
        _playedFindSE = false;
        _isChasing = false;
    }

    void Update()
    {
        _targetTransform = TaggerVision.Target;

        // 発見時には、Find→Chaseの流れ
        if (_targetTransform != null)
        {
            // 発見SEの再生は一度だけ
            if (!_playedFindSE) _audioSource.PlayOneShot(FindSE);
            _playedFindSE = true;

            // 徘徊の移動を無効化するため
            _wanderField.enabled = false;

            // Findアニメーション終了後、自動でChaseアニメーションへ
            _animator.SetBool("isFinding", true);

            // 追跡用BGMの再生
            if (!_isChasing)
            {
                _isChasing = true;
                BGMManager.Instance.OnTaggerStartChasing();
            }
        }
        else
        {
            // 見失った場合は、Wanderアニメーションへ
            _playedFindSE = false;
            _animator.SetBool("isFinding", false);

            // 追跡用BGMの停止
            if (_isChasing)
            {
                _isChasing = false;
                BGMManager.Instance.OnTaggerStopChasing();
            }
        }
    }

    // 徘徊(Wanderアニメーション開始時にも実行)
    private void SetStateWandering()
    {
        // スピードを徘徊状態に合わせるため、徘徊用スクリプトのみ有効化
        if (!_wanderField.enabled) _wanderField.enabled = true;
        if (_chasePlayer.enabled) _chasePlayer.enabled = false;
    }

    // 追跡(Chaseアニメーション開始時に実行)
    private void SetStateChasing()
    {
        if (!_chasePlayer.enabled)
        {
            _chasePlayer.enabled = true;
            _chasePlayer.SetTarget(_targetTransform);
        }
    }
}
