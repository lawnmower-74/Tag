using UnityEngine;

/// <summary>Playerの移動操作・カメラ操作</summary>
public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float WalkSpeed = 3.0f;
    public float RunSpeed = 6.0f;
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

    // Playerの移動操作
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(horizontalInput, 0, verticalInput);

        bool isMoving = inputDir.magnitude > 0.01f;

        // 移動スピードを選択
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float moveSpeed = isRunning ? RunSpeed : WalkSpeed;

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

        _animator.SetBool("isWalking", isMoving && !isRunning);
        _animator.SetBool("isRunnig", isMoving && isRunning);
    }

    // 追尾カメラの視点操作
    private void CamRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        TrackingCamera.transform.Rotate(Vector3.up, mouseX);
    }

}
