using System;
using TMPro;
using UnityEngine;

/// <summary>プレイ時間のカウントダウン・ゲームクリアの管理</summary>
public class TimeCounter : MonoBehaviour
{
    public GameObject Player;
    public GameObject GameClearWindow;
    public float PlayTimeSeconds => _playTimeSeconds;
    
    private TextMeshProUGUI _timeText;
    private int _defaultPlayTimeMin = 3;
    private float _playTimeSeconds;
    private const string PLAY_TIME_KEY = "PlayTime";

    void Start()
    {
        _timeText = GetComponent<TextMeshProUGUI>();

        // プレイ時間の単位換算
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

        // 時間内、鬼から逃げ切れればゲームクリア
        if (_playTimeSeconds <= 0)
        {
            Destroy(Player);
            BGMManager.Instance.OnTaggerStopChasing();
            
            GameClearWindow.SetActive(true);
            enabled = false;
        }
    }
}