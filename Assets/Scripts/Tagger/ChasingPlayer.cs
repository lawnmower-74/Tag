using UnityEngine;
using UnityEngine.AI;

/// <summary>Taggerの追跡行動を制御</summary>
public class ChasingPlayer : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _playerTransform;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>Playerのを座標を元にターゲット化</summary>
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
        else
        {
            _agent.ResetPath();
        }
    }
}
