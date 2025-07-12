using TMPro;
using UnityEngine;

/// <summary>プレイ時間をPlayerPrefsに保存(他スクリプトへ提供するため)</summary>
public class PlayTimeSetting : MonoBehaviour
{
    private TMP_InputField _inputField;
    private TMP_Text _placeholder;

    private const string PLAY_TIME_KEY = AppConstants.PLAY_TIME_KEY;
    private const int DEFAULT_PLAY_MINUTES = AppConstants.DEFAULT_PLAY_MINUTES;
    private const int MINIMUM_PLAY_MINUTES = AppConstants.MINIMUM_PLAY_MINUTES;
    private const int MAX_PLAY_MINUTES = AppConstants.MAX_PLAY_MINUTES;

    void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
        _placeholder = _inputField.placeholder.GetComponent<TMP_Text>();

        // 初期値
        _inputField.text = DEFAULT_PLAY_MINUTES.ToString();
        _placeholder.text = MINIMUM_PLAY_MINUTES + "〜" + MAX_PLAY_MINUTES + "で（未入力だと" + DEFAULT_PLAY_MINUTES + "分）";
        PlayerPrefs.SetInt(PLAY_TIME_KEY, DEFAULT_PLAY_MINUTES);

        // 入力された際に実行
        _inputField.onEndEdit.AddListener(OnInputEndEdit);

    }
    
    private void OnInputEndEdit(string inputValue)
    {
        int parsedValue;

        // 入力制限
        if (string.IsNullOrEmpty(inputValue) || !int.TryParse(inputValue, out parsedValue))
        {
            parsedValue = DEFAULT_PLAY_MINUTES;
        }

        if (parsedValue < MINIMUM_PLAY_MINUTES)
        {
            parsedValue = MINIMUM_PLAY_MINUTES;
        }
        else if (parsedValue > MAX_PLAY_MINUTES)
        {
            parsedValue = MAX_PLAY_MINUTES;
        }

        _inputField.text = parsedValue.ToString();

        PlayerPrefs.SetInt(PLAY_TIME_KEY, parsedValue);
    }
}
