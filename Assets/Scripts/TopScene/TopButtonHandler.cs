using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>TOPシーンのボタンに適用</summary>
public class TopButtonHandler : MonoBehaviour
{
    public GameObject DescriptionPanel;
    public GameObject SettingPanel;

    /// <summary>遊び方説明パネルの表示</summary>
    public void DisplayDescriptionPanel()
    {
        DescriptionPanel.SetActive(true);
    }

    /// <summary>プレイ時間設定用パネルの表示</summary>
    public void SetPlayTime()
    {
        SettingPanel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
