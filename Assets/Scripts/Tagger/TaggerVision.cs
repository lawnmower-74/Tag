using UnityEngine;

/// <summary>Playerの検出状態を提供</summary>
public class TaggerVision : MonoBehaviour
{
    public GameObject Target => _target;
    private GameObject _target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) _target = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) _target = null;
    }
}
