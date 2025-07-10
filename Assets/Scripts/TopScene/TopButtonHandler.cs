using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>TOP画面のボタンに適用</summary>
public class TopButtonHandler : MonoBehaviour
{
    public GameObject SettingPanel;

    /// <summary>プレイ時間設定用パネルの表示</summary>
    public void SetPlayTime()
    {
        SettingPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
