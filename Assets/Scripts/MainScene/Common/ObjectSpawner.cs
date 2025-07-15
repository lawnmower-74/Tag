using System.Collections.Generic;
using UnityEngine;

/// <summary>オブジェクトをフィールドに出現</summary>
public class ObjectSpawner : MonoBehaviour
{
    public GameObject TargetObject;
    public int SpawnLimit;
    public float InitialSpawnDelaySeconds;
    public float SpawnIntervalSeconds;
    public List<Transform> SpawnPoints;
    public int SpawnedCounts => _spawnedCounts;

    private int _spawnedCounts = 0;

    void Start()
    {
        // インターバル付きのオブジェクトの出現
        InvokeRepeating("SpawnObject", InitialSpawnDelaySeconds, SpawnIntervalSeconds);
    }

    private void SpawnObject()
    {
        if (SpawnLimit <= _spawnedCounts)
        {
            CancelInvoke("SpawnObject");
            return;
        }
        else
        {
            // スポーン位置はランダムに選択
            int randomIndex = Random.Range(0, SpawnPoints.Count);
            Transform randomSpawnPoint = SpawnPoints[randomIndex];
            Instantiate(TargetObject, randomSpawnPoint.position, randomSpawnPoint.rotation);

            _spawnedCounts++;
        }
    }
}
