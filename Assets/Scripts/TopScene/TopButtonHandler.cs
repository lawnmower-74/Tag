using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>TopSceneに属するボタンの挙動を制御</summary>
public class TopButtonHandler : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
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
