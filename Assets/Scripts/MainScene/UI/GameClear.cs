using UnityEngine;

/// <summary>ゲームクリア時に実行</summary>
public class GameClear : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameClearWindow;
    public TimeCounter TimeCounter;

    void Update()
    {
        if (TimeCounter.PlayTimeSeconds <= 0)
        {
            Destroy(Player);
            BGMManager.Instance.OnTaggerStopChasing();

            GameClearWindow.SetActive(true);
            enabled = false;
        }
    }
}
