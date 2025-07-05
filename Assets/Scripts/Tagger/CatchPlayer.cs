using UnityEngine;

/// <summary>Playerを捕まえ消滅させる</summary>
public class CatchPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
