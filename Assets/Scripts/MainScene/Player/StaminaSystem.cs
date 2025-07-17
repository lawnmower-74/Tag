using UnityEngine;
using UnityEngine.UI;

/// <summary>Playerのスタミナを管理</summary>
public class StaminaSystem : MonoBehaviour
{
    public PlayerController PlayerController;
    public Image NormalStaminaGauge; // 通常のスタミナゲージ
    public Image TiredStaminaGauge; // 疲労状態のスタミナゲージ
    public Image BuffedStaminaGauge; // ポーション効果中のスタミナゲージ

    // スタミナの量・消費・回復速度
    private float _maxStamina = 100f;
    private float _currentStamina;
    private float _runCostPerSecond = 20f;
    private float _recoverRatePerSecond = 15f;

    // ポーションの持続時間
    private float _effectiveTime = 60f;
    private float _remainingTime = 0f;

    // スタミナの状態判定
    private bool _isTired = false;
    private bool _isBuffed = false;

    void Awake()
    {
        _currentStamina = _maxStamina;
    }

    void Start()
    {
        // 初期状態は通常のスタミナゲージを表示
        UpdateStaminaUI();
    }

    void Update()
    {
        // ポーション取得時
        if (_isBuffed)
        {
            // 効果時間のカウントダウン
            _remainingTime -= Time.deltaTime;
            if (_remainingTime <= 0f)
            {
                DisableStaminaBuff();
            }
        }
        else
        {
            bool isRunning = PlayerController.IsRunning;

            if (isRunning && !_isTired)
            {
                // スタミナを消費
                _currentStamina -= _runCostPerSecond * Time.deltaTime;
                _currentStamina = Mathf.Max(_currentStamina, 0);

                // スタミナが0になったら疲労状態(走行不能)にする
                if (_currentStamina == 0) _isTired = true;
            }
            else
            {
                // スタミナを回復
                _currentStamina += _recoverRatePerSecond * Time.deltaTime;
                _currentStamina = Mathf.Min(_currentStamina, _maxStamina);

                // スタミナが最大値に戻ったら疲労状態を解除
                if (_currentStamina == _maxStamina) _isTired = false;
            }

        }
        UpdateStaminaUI();
    }

    /// <summary>
    /// 走行可能か判定を行う
    /// </summary>
    /// <returns></returns>
    public bool CanRun()
    {
        return _isBuffed || (!_isTired && _currentStamina > 0);
    }

    /// <summary>
    /// スタミナ減少を無効化する
    /// </summary>
    public void EnableStaminaBuff()
    {
        // ポーション効果中の状態にする
        _isBuffed = true;
        _remainingTime = _effectiveTime; // タイマーのセット

        // 疲労解除・スタミナ全回復
        _isTired = false;
        _currentStamina = _maxStamina;

        // バフ状態のゲージを表示
        UpdateStaminaUI();
    }

    // ポーションの効果切れ
    private void DisableStaminaBuff()
    {
        _isBuffed = false;
        _remainingTime = 0f;
        
        // 通常状態のゲージを表示
        UpdateStaminaUI();
    }

    // 状態に合わせて表示するスタミナ量・ゲージを選択
    private void UpdateStaminaUI()
    {
        // ポーション効果中はカウントダウンに伴いゲージが減っていく
        float fillAmount = _isBuffed ? (_remainingTime / _effectiveTime) : (_currentStamina / _maxStamina);

        if (_isBuffed)
        {
            SetStaminaGaugeState(false, false, true);
            BuffedStaminaGauge.fillAmount = fillAmount;
        }
        else if (_isTired)
        {
            SetStaminaGaugeState(false, true, false);
            TiredStaminaGauge.fillAmount = fillAmount;
        }
        else // 通常状態
        {
            SetStaminaGaugeState(true, false, false);
            NormalStaminaGauge.fillAmount = fillAmount;
        }
    }

    /// <summary>
    /// 表示するスタミナゲージの選択
    /// </summary>
    /// <param name="isNormal">通常状態ゲージを表示</param>
    /// <param name="isTired">疲労状態ゲージを表示</param>
    /// <param name="isBuffed">バフ状態ゲージを表示</param>
    private void SetStaminaGaugeState(bool isNormal, bool isTired, bool isBuffed)
    {
        NormalStaminaGauge.gameObject.SetActive(isNormal);
        TiredStaminaGauge.gameObject.SetActive(isTired);
        BuffedStaminaGauge.gameObject.SetActive(isBuffed);
    }
}
