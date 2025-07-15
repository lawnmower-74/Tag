using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private StaminaSystem _staminaSystem;
    private float _rotationSpeed = 50f;

    void Awake()
    {
        _staminaSystem = FindFirstObjectByType<StaminaSystem>();
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

            Transform parentTransform = transform.parent;
            Destroy(parentTransform.gameObject);
        }
    }
}
