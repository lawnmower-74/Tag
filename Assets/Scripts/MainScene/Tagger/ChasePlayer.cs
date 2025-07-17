using UnityEngine;
using UnityEngine.AI;

/// <summary>鬼の追跡行動を制御</summary>
public class ChasePlayer : MonoBehaviour
{
    public float ChaseSpeed = 6.0f;

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
