using UnityEngine;

/// <summary>ゲームクリア時に実行</summary>
public class GameClear : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameClearWindow;
    public GameObject ClearEffect;
    public AudioClip ClearSE;
    public TimeCounter TimeCounter;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (TimeCounter.PlayTimeSeconds <= 0)
        {
            // ゲームクリア時のエフェクト
            Instantiate(ClearEffect, Player.transform.position + Vector3.up * 5f, Quaternion.identity);

            // ゲームクリア時のSE
            _audioSource.PlayOneShot(ClearSE);

            // Player・BGMを消滅
            Destroy(Player);
            BGMManager.Instance.OnTaggerStopChasing();

            GameClearWindow.SetActive(true);
            enabled = false;
        }
    }
}
