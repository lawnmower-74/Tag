using System.Collections.Generic;
using UnityEngine;

/// <summary>鬼をフィールドに出現</summary>
public class TaggerSpawner : MonoBehaviour
{
    public GameObject Tagger;
    public int SpawnCounts = 12;
    public float InitialSpawnDelay = 10.0f;
    public float SpawnInterval = 20.0f;
    public List<Transform> SpawnPoints;
    public int SpawnedCounts => _spawnedCounts;
    private int _spawnedCounts = 0;

    void Start()
    {
        // インターバル付きの鬼の出現
        InvokeRepeating("SpawnTagger", InitialSpawnDelay, SpawnInterval);
    }

    private void SpawnTagger()
    {
        if (SpawnCounts < _spawnedCounts)
        {
            CancelInvoke("SpawnTagger");
            return;
        }
        else
        {
            // スポーン位置はランダムに選択
            int randomIndex = Random.Range(0, SpawnPoints.Count);
            Transform randomSpawnPoint = SpawnPoints[randomIndex];
            Instantiate(Tagger, randomSpawnPoint.position, randomSpawnPoint.rotation);

            _spawnedCounts++;
        }
    }
}
