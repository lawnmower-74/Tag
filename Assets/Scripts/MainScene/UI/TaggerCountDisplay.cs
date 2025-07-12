using TMPro;
using UnityEngine;

public class TaggerCountDisplay : MonoBehaviour
{
    public TaggerSpawner TaggerSpawner;
    private TextMeshProUGUI _spawnCountText;

    void Start()
    {
        _spawnCountText = GetComponent<TextMeshProUGUI>();
    }

  void Update()
    {
        _spawnCountText.text = TaggerSpawner.SpawnedCounts + "/" + TaggerSpawner.SpawnCounts;
    }
}
