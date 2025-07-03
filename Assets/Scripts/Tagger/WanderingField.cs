using UnityEngine;
using UnityEngine.AI;

/// <summary>Taggerの徘徊行動を制御</summary>
public class WanderingField : MonoBehaviour
{
    public float WanderRadius = 100.0f;
    public float DestinationThreshold = 2.0f;
    private NavMeshAgent _agent;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
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

        // 目的地の座標がField外となる場合に備えて(randomDirをもとにhitを検索)
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDir, out hit, WanderRadius, NavMesh.AllAreas))
        {
            _agent.SetDestination(hit.position);
        }
        else
        {
            SetNewDestination();
        }
    }
}
