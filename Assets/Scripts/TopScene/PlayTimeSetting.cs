using TMPro;
using UnityEngine;

/// <summary>プレイ時間を設定(PlayerPrefsで他スクリプトへ提供)</summary>
public class PlayTimeSetting : MonoBehaviour
{
    public int DefaultPlayTimeMin = 3;

    private const string PLAY_TIME_KEY = "PlayTime";
    private TMP_InputField _inputField;

    void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();

        // 初期値
        PlayerPrefs.SetInt(PLAY_TIME_KEY, DefaultPlayTimeMin);

        // 入力値をPlayerPrefsに保存
        _inputField.onEndEdit.AddListener(OnInputEndEdit);
    }
    
    private void OnInputEndEdit(string inputValue)
    {
        int parsedValue;

        if (string.IsNullOrEmpty(inputValue) || !int.TryParse(inputValue, out parsedValue))
        {
            parsedValue = DefaultPlayTimeMin;
        }

        // プレイ時間の入力制限（1以上5以下の整数）
        if (parsedValue < 1)
        {
            parsedValue = 1;
        }
        else if (parsedValue > 5)
        {
            parsedValue = 5;
        }

        // UIに反映
        _inputField.text = parsedValue.ToString();

        // PlayerPrefsに保存
        PlayerPrefs.SetInt(PLAY_TIME_KEY, parsedValue);
    }
}
