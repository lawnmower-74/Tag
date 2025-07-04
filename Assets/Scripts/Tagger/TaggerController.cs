using UnityEngine;

/// <summary>Playerの検出状況ごとで挙動を振り分ける</summary>
public class TaggerController : MonoBehaviour
{
    public TaggerVision TaggerVisionScript;
    public AudioClip FindSound;
    private WanderingField _wanderingFieldScript;
    private ChasingPlayer _chasingPlayerScript;
    private Transform _targetTransform;
    private Animator _animator;
    private AudioSource _audioSource;
    private bool _hasTarget = false;

    void Awake()
    {
        _wanderingFieldScript = GetComponent<WanderingField>(); // 徘徊状態を管理
        _chasingPlayerScript = GetComponent<ChasingPlayer>(); // 追跡状態を管理

        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        SetStateWandering();
        _hasTarget = false;
    }

    void Update()
    {
        _targetTransform = TaggerVisionScript.Target;

        if (_targetTransform != null)
        {
            _wanderingFieldScript.enabled = false; // ※徘徊の移動を無効化するため
            
            // 発見時のSE
            if (!_hasTarget) _audioSource.PlayOneShot(FindSound);
            _hasTarget = true;

            _animator.SetBool("isFinding", true);
        }
        else
        {
            _hasTarget = false;
            _animator.SetBool("isFinding", false);
        }
    }

    // 徘徊(※Wanderアニメーション開始時にも実行)
    private void SetStateWandering()
    {
        // 徘徊用スクリプトのみ有効化
        if (!_wanderingFieldScript.enabled) _wanderingFieldScript.enabled = true;
        if (_chasingPlayerScript.enabled) _chasingPlayerScript.enabled = false;
    }

    // 追跡(※Chaseアニメーション開始時に実行)
    private void SetStateChasing()
    {
        if (!_chasingPlayerScript.enabled)
        {
            _chasingPlayerScript.enabled = true;
            _chasingPlayerScript.SetTarget(_targetTransform);
        }
    }
}
