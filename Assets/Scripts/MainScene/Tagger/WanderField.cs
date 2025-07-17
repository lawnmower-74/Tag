using UnityEngine;
using UnityEngine.AI;

/// <summary>鬼の徘徊行動を制御</summary>
public class WanderField : MonoBehaviour
{
    public float WanderSpeed = 3.0f;
    public float WanderRadius = 100.0f;
    public float DestinationThreshold = 2.0f;
    private NavMeshAgent _agent;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        _agent.speed = WanderSpeed;
        SetNewDestination();
    }

    void OnDisable()
    {
        _agent.ResetPath();
    }

    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance <= DestinationThreshold)
        {
            SetNewDestination();
        }
    }

    // 目的地(徘徊先)をセット
    private void SetNewDestination()
    {
        // 現在地から次の目的地の座標を生成
        Vector3 randomDir = Random.insideUnitSphere * WanderRadius;
        randomDir += transform.position;

        // randomDirから指定範囲内で最も近いNavMesh上の座標(hit)を検索
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDir, out hit, WanderRadius, NavMesh.AllAreas))
        {
            _agent.SetDestination(hit.position);
        }
        else
        {
            // 上記でNavMesh上の有効な座標が見つからなかったとき
            SetNewDestination();
        }
    }
}
