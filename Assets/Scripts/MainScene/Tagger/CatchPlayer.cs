using UnityEngine;

/// <summary>Playerを捕まえ消滅させる</summary>
public class CatchPlayer : MonoBehaviour
{
    public GameObject DestroyEffect;
    public AudioClip DestroySE;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 消滅時エフェクト
            GameObject playerObject = other.gameObject;
            Instantiate(DestroyEffect, playerObject.transform.position, Quaternion.identity);

            // 消滅時SE
            _audioSource.PlayOneShot(DestroySE);

            // Playerを消滅
            Destroy(other.gameObject);
        }
    }
}
