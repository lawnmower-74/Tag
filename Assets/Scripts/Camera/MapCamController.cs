using UnityEngine;

/// <summary>ミニマップ用カメラ(Playerを真上から追跡)</summary>
public class MapCamController : MonoBehaviour
{
    public Transform TargetPlayer;
    public Vector3 Offset = new Vector3(0, 50, 0);

    void LateUpdate()
    {
        if (TargetPlayer != null)
        {
            transform.position = TargetPlayer.position + Offset;
            transform.rotation = Quaternion.Euler(90f, 0f, 0f); // 回転は固定
        }
    }
}
