using UnityEngine;

/// <summary>Playerの移動操作・カメラ操作</summary>
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public StaminaSystem StaminaSystem;
    public float WalkSpeed = 3.0f;
    public float RunSpeed = 6.0f;
    public bool IsRunning { get; private set; }

    private Animator _animator;
    private Rigidbody _rigidbody;

    [Header("Camera Settings")]
    public Transform TrackingCamera;
    public float MouseSensitivity = 2.0f;


    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();

        // カメラ操作時にはマウスを非表示化
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        CamRotation();
        TrackingCamera.transform.position = transform.position; // Playerを追尾
    }

    // ゲームオーバー／クリア時
    void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // スタミナゲージを非表示
        if (StaminaSystem != null) StaminaSystem.gameObject.SetActive(false);
    }

    // Playerの移動操作
    private void Move()
    {
        // 入力の取得
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool runningInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        Vector3 inputDir = new Vector3(horizontalInput, 0, verticalInput);
        bool isMoving = inputDir.magnitude > 0.01f;

        // スタミナを参照し走行可能かチェック
        IsRunning = isMoving && runningInput && StaminaSystem.CanRun();

        // 移動速度の決定
        float moveSpeed = IsRunning ? RunSpeed : WalkSpeed;

        if (isMoving)
        {
            // 移動の向き・大きさ（水平方向のみ）
            Vector3 moveDir = TrackingCamera.TransformDirection(inputDir);
            moveDir.y = 0;
            moveDir.Normalize();

            // Playerの向き
            transform.rotation = Quaternion.LookRotation(moveDir);

            // 重力による自然落下
            Vector3 gravityVelocity = new Vector3(0, _rigidbody.linearVelocity.y, 0);

            _rigidbody.linearVelocity = moveDir * moveSpeed + gravityVelocity;
        }
        else
        {
            _rigidbody.linearVelocity = new Vector3(0, _rigidbody.linearVelocity.y, 0);
        }

        _animator.SetBool("isWalking", isMoving && !IsRunning);
        _animator.SetBool("isRunnig", isMoving && IsRunning);
    }

    // 追尾カメラの視点操作
    private void CamRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        TrackingCamera.transform.Rotate(Vector3.up, mouseX);
    }

}
