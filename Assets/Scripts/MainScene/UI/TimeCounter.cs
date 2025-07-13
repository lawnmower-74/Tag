using System;
using TMPro;
using UnityEngine;

/// <summary>プレイ時間のカウントダウン</summary>
public class TimeCounter : MonoBehaviour
{
    public GameObject Player;
    public float PlayTimeSeconds => _playTimeSeconds;

    private TextMeshProUGUI _timeText;
    private float _playTimeSeconds;

    private const string PLAY_TIME_KEY = AppConstants.PLAY_TIME_KEY;
    private const int DEFAULT_PLAY_MINUTES = AppConstants.DEFAULT_PLAY_MINUTES;

    void Start()
    {
        _timeText = GetComponent<TextMeshProUGUI>();

        // プレイ時間の単位変換
        int playTimeMinutes = PlayerPrefs.GetInt(PLAY_TIME_KEY, DEFAULT_PLAY_MINUTES);
        _playTimeSeconds = playTimeMinutes * 60;
    }

    void Update()
    {
        // ゲームオーバー／クリア時にはカウントを止める
        if (!Player || _playTimeSeconds <= 0) return;

        // カウントダウン
        _playTimeSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)_playTimeSeconds);
        _timeText.text = span.ToString(@"mm\:ss");
    }
}