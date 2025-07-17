using UnityEngine;

/// <summary>ポーション取得時の挙動などを制御</summary>
public class PotionSystem : MonoBehaviour
{
    private StaminaSystem _staminaSystem;
    private GameObject _uiCanvas;
    private GameObject _potionPanel;
    private float _rotationSpeed = 50f;
    private const string POTION_PANEL_SHOWN_KEY = AppConstants.POTION_PANEL_SHOWN_KEY;

    void Awake()
    {
        _staminaSystem = FindFirstObjectByType<StaminaSystem>();

        // 初期状態では非アクティブな説明用パネルを取得
        _uiCanvas = GameObject.Find("UICanvas");
        if (_uiCanvas != null)
        {
            Transform panelTransform = _uiCanvas.transform.Find("PotionPanel");
            if (panelTransform != null)
            {
                _potionPanel = panelTransform.gameObject;
            }
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
    }

    // プレイヤーをスタミナ減少無効状態にする
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _staminaSystem.EnableStaminaBuff();

            // ポーション含め、属する親オブジェクト内のすべてを削除（目印など）
            Transform parentTransform = transform.parent;
            Destroy(parentTransform.gameObject);

            // 説明用パネルの表示・一時停止（※初回限り）
            if (PlayerPrefs.GetInt(POTION_PANEL_SHOWN_KEY, 0) == 0)
            {
                _potionPanel.SetActive(true);
                Time.timeScale = 0f;

                // パネル操作のためカーソルを表示
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                // 表示済みフラグを保存
                PlayerPrefs.SetInt(POTION_PANEL_SHOWN_KEY, 1);
                PlayerPrefs.Save();
            }

        }
    }
}
