using UnityEngine;

/// <summary>ミニマップ用カメラ</summary>
public class MapCamSettings : MonoBehaviour
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
