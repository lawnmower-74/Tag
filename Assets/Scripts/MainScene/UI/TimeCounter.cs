using System;
using TMPro;
using UnityEngine;

/// <summary>プレイ時間のカウントダウン・ゲームクリア状態を管理</summary>
public class TimeCounter : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameClearWindow;
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
        if (!Player) return;

        // カウントダウン
        _playTimeSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)_playTimeSeconds);
        _timeText.text = span.ToString(@"mm\:ss");

        // 時間内逃げ切れれば、ゲームクリア
        if (_playTimeSeconds <= 0) GameClear();
    }

    private void GameClear()
    {
        Destroy(Player);
        BGMManager.Instance.OnTaggerStopChasing();

        GameClearWindow.SetActive(true);
        enabled = false;
    }
}