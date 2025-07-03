using UnityEngine;

/// <summary>Playerの検出状況ごとで挙動を振り分ける</summary>
public class TaggerController : MonoBehaviour
{
    public TaggerVision TaggerVisionScript;
    private WanderingField _wanderingFieldScript;
    private ChasingPlayer _chasingPlayerScript;

    void Awake()
    {
        _wanderingFieldScript = GetComponent<WanderingField>(); // 徘徊状態を管理
        _chasingPlayerScript = GetComponent<ChasingPlayer>(); // 追跡状態を管理
    }

    void Start()
    {
        SetStateWandering();
    }

    void Update()
    {
        GameObject target = TaggerVisionScript.Target;

        if (target != null)
        {
            SetStateChasing(target.transform); // 追跡
        }
        else
        {
            SetStateWandering(); // 徘徊
        }
    }

    // 徘徊
    private void SetStateWandering()
    {
        // 徘徊用スクリプトのみ有効化
        if (!_wanderingFieldScript.enabled)
        {
            _wanderingFieldScript.enabled = true;
        }
        if (_chasingPlayerScript.enabled)
        {
            _chasingPlayerScript.enabled = false;
        }
    }

    // 追跡
    private void SetStateChasing(Transform playerTransform)
    {
        // 追跡用スクリプトのみ有効化・ターゲットの譲渡
        if (!_chasingPlayerScript.enabled)
        {
            _chasingPlayerScript.enabled = true;
            _chasingPlayerScript.SetTarget(playerTransform);
        }
        if (_wanderingFieldScript.enabled)
        {
            _wanderingFieldScript.enabled = false;
        }
    }
}
