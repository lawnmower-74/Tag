using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonHandler : MonoBehaviour
{
    public void ReStartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ToTop()
    {
        SceneManager.LoadScene("TopScene");
    }
}
