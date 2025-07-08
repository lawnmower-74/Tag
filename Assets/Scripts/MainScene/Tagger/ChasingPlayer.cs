using UnityEngine;
using UnityEngine.AI;

/// <summary>Taggerの追跡行動を制御</summary>
public class ChasingPlayer : MonoBehaviour
{
    public float ChaseSpeed = 5.0f;

    private NavMeshAgent _agent;
    private Transform _playerTransform;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void OnEnable()
    {
        _agent.speed = ChaseSpeed;
    }

    /// <summary>Player(座標)をターゲット化</summary>
    public void SetTarget(Transform player)
    {
        _playerTransform = player;
    }

    void Update()
    {
        if (_playerTransform != null)
        {
            _agent.SetDestination(_playerTransform.position);
        }
    }
}
