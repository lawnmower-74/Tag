using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopScene : MonoBehaviour
{
    // スタートボタンクリック時に実行
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
