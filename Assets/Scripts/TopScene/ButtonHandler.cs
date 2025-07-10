using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>TOP画面のボタンに適用</summary>
public class ButtonHandler : MonoBehaviour
{
    public GameObject SettingPanel;

    public void SetPlayTime()
    {
        SettingPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
