using System.Collections.Generic;
using UnityEngine;

/// <summary>鬼をフィールドに出現</summary>
public class TaggerSpawner : MonoBehaviour
{
    public GameObject Tagger;
    public float InitialSpawnDelay = 10.0f;
    public float SpawnInterval = 30.0f;
    public List<Transform> SpawnPoints;
    private List<Transform> _availableSpawnPoints;

    void Start()
    {
        _availableSpawnPoints = new List<Transform>(SpawnPoints);

        // Taggerの出現
        InvokeRepeating("SpawnTagger", InitialSpawnDelay, SpawnInterval);
    }

    private void SpawnTagger()
    {
        if (_availableSpawnPoints.Count == 0)
        {
            CancelInvoke("SpawnTagger");
            return;
        }

        // スポーン位置は指定箇所からランダムに選択
        int randomIndex = Random.Range(0, _availableSpawnPoints.Count);
        Transform randomSpawnPoint = _availableSpawnPoints[randomIndex];
        Instantiate(Tagger, randomSpawnPoint.position, randomSpawnPoint.rotation);

        // 一度使われたスポーン位置は再利用不可とする
        _availableSpawnPoints.RemoveAt(randomIndex);
    }
}
