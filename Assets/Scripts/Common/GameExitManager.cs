using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>ゲーム終了に関する制御</summary>
public class GameExitManager : MonoBehaviour
{
    // Escapeキーでアプリケーションを終了
    public void OnEscape(InputAction.CallbackContext context)
    {
        if (context.performed) Application.Quit();
    }

    // ゲーム終了時にPlayerPrefsのデータを消去
    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs cleared on application quit.");
    }
}
