using UnityEngine;
using UnityEngine.UI;

/// <summary>Playerのスタミナを管理</summary>
public class StaminaSystem : MonoBehaviour
{
    public GameObject Player;
    public Image NormalStaminaGauge; // 通常のスタミナゲージ
    public Image DepletedStaminaGauge; // 疲労状態のスタミナゲージ
    public float MaxStamina = 100f;
    public float RunCostPerSecond = 20f;
    public float RecoverRatePerSecond = 15f;

    private PlayerController _playerController;
    private float _currentStamina;
    private bool _isTired = false;

    void Awake()
    {
        _currentStamina = MaxStamina;
    }

    void Start()
    {
        _playerController = Player.GetComponent<PlayerController>();

        NormalStaminaGauge.gameObject.SetActive(true);
        DepletedStaminaGauge.gameObject.SetActive(false);

        UpdateStaminaUI();
    }

    void Update()
    {
        if (_playerController == null) return;

        bool isRunning = _playerController.IsRunning;

        if (isRunning && !_isTired)
        {
            // スタミナを消費
            _currentStamina -= RunCostPerSecond * Time.deltaTime;
            _currentStamina = Mathf.Max(_currentStamina, 0);

            // スタミナが0になったら疲労状態(走行不能)にする
            if (_currentStamina == 0)
            {
                _isTired = true;
                NormalStaminaGauge.gameObject.SetActive(false);
                DepletedStaminaGauge.gameObject.SetActive(true);
            }
        }
        else
        {
            // スタミナを回復
            _currentStamina += RecoverRatePerSecond * Time.deltaTime;
            _currentStamina = Mathf.Min(_currentStamina, MaxStamina);

            // スタミナが最大値に戻ったら疲労状態を解除
            if (_currentStamina == MaxStamina)
            {
                _isTired = false;
                NormalStaminaGauge.gameObject.SetActive(true);
                DepletedStaminaGauge.gameObject.SetActive(false);
            }
        }

        UpdateStaminaUI();
    }

    private void UpdateStaminaUI()
    {
        if (NormalStaminaGauge.gameObject.activeSelf)
        {
            NormalStaminaGauge.fillAmount = _currentStamina / MaxStamina;
        }
        else if (DepletedStaminaGauge.gameObject.activeSelf)
        {
            DepletedStaminaGauge.fillAmount = _currentStamina / MaxStamina;
        }
    }

    /// <summary>走行可能か判定を行う</summary>
    public bool CanRun()
    {
        return !_isTired && _currentStamina > 0;
    }
}
