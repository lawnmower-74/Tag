using UnityEngine;
using UnityEngine.AI;

public class TaggerController : MonoBehaviour
{
    public float PatrolRadius = 100.0f;
    public float DestinationThreshold = 2.0f;
    private NavMeshAgent _agent;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        SetNewDestination();
    }

    void Update()
    {
        // 目的地までの経路の計算が完了・目的地までの距離がしきい値を下回ったとき
        if (!_agent.pathPending && _agent.remainingDistance <= DestinationThreshold)
        {
            SetNewDestination();
        }
    }

    // 目的地(徘徊先)をセット
    private void SetNewDestination()
    {
        // 現在地から次の目的地の座標を生成
        Vector3 randomDir = Random.insideUnitSphere * PatrolRadius;
        randomDir += transform.position;

        // 目的地の座標がField外となる場合に備えて(randomDirをもとにhitを検索)
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDir, out hit, PatrolRadius, NavMesh.AllAreas))
        {
            _agent.SetDestination(hit.position);
        }
        else
        {
            SetNewDestination(); 
        }
    }
}
