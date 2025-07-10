using System;
using TMPro;
using UnityEngine;

/// <summary>制限時間のカウント</summary>
public class TimeCounter : MonoBehaviour
{
    public GameObject Player;
    
    private TextMeshProUGUI _timeText;
    private int _defaultPlayTimeMin = 3;
    private float _playTimeSeconds;
    private const string PLAY_TIME_KEY = "PlayTime";

    private void Start()
    {
        _timeText = GetComponent<TextMeshProUGUI>();

        // 設定したプレイ時間を取得
        int playTimeMinutes = PlayerPrefs.GetInt(PLAY_TIME_KEY, _defaultPlayTimeMin);
        _playTimeSeconds = playTimeMinutes * 60;
    }

    void Update()
    {
        if (!Player) return;

        // カウントダウン
        _playTimeSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)_playTimeSeconds);
        _timeText.text = span.ToString(@"mm\:ss");

        if (_playTimeSeconds <= 0)
        {
            // TODO：0秒になったときの処理
            return;
        }
    }
}