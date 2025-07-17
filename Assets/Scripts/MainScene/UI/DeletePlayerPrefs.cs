using UnityEngine;

/// <summary>ゲーム終了時にPlayerPrefsのデータを消去</summary>
public class DeletePlayerPrefs : MonoBehaviour
{
    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll(); 
        PlayerPrefs.Save();
    }
}
