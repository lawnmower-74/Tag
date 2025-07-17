using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>ボタン操作を制御</summary>
public class ButtonHandler : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);

        // 一時停止などしていた場合、それらを解除
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ToTop()
    {
        SceneManager.LoadScene("TopScene");
    }
}
