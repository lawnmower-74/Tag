using UnityEngine;

/// <summary>ミニマップ用カメラ</summary>
public class MapCamSettings : MonoBehaviour
{
    public Vector3 CamPosition = new Vector3(0, 50, 0);

    void LateUpdate()
    {
        transform.position = CamPosition;
        transform.rotation = Quaternion.Euler(90f, 0f, 0f); // 回転は固定
    }
}
