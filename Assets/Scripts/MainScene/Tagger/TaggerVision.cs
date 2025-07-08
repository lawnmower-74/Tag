using UnityEngine;

/// <summary>Playerの検出状態を提供</summary>
public class TaggerVision : MonoBehaviour
{
    public Transform Target => _target;
    private Transform _target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) _target = other.gameObject.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) _target = null;
    }
}
