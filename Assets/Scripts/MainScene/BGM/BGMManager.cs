using UnityEngine;

/// <summary>追跡用BGMの再生・停止</summary>
public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance { get; private set; }
    private AudioSource _chaseBGM;
    private int _chasersCount = 0;

    void Awake()
    {
        _chaseBGM = GetComponent<AudioSource>();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    /// <summary>追跡用BGMの再生</summary>
    public void OnTaggerStartChasing()
    {
        _chasersCount++;
        if (_chasersCount == 1)
        {
            if (!_chaseBGM.isPlaying) _chaseBGM.Play();
        }
    }

    /// <summary>追跡用BGMの停止</summary>
    public void OnTaggerStopChasing()
    {
        _chasersCount--;
        if (_chasersCount <= 0)
        {
            _chasersCount = 0;
            if (_chaseBGM.isPlaying) _chaseBGM.Stop();
        }
    }
}