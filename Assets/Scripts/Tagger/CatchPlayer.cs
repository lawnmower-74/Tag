using UnityEngine;

/// <summary>Playerを捕まえ消滅させる</summary>
public class CatchPlayer : MonoBehaviour
{
    public GameObject DestroyEffect;
    public AudioClip DestroySE;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 消滅時エフェクト
            GameObject playerObject = other.gameObject;
            Instantiate(DestroyEffect, playerObject.transform.position, Quaternion.identity);

            // 消滅時SE
            AudioSource.PlayClipAtPoint(DestroySE, playerObject.transform.position);

            Destroy(other.gameObject);
        }
    }
}
