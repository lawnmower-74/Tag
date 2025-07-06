using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>制限時間のカウント</summary>
public class TimeCounter : MonoBehaviour
{
    public GameObject Player;
    public int CountDownMinutes = 3;
    private float CountDownSeconds;
    private Text TimeText;

    private void Start()
    {
        TimeText = GetComponent<Text>();
        CountDownSeconds = CountDownMinutes * 60;
    }

    void Update()
    {
        if (!Player) return;

        // カウントダウン
        CountDownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)CountDownSeconds);
        TimeText.text = span.ToString(@"mm\:ss");

        if (CountDownSeconds <= 0)
        {
            // TODO：0秒になったときの処理
            return;
        }
    }
}