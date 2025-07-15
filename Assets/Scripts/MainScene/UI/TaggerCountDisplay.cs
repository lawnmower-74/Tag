using TMPro;
using UnityEngine;

public class TaggerCountDisplay : MonoBehaviour
{
    public ObjectSpawner ObjectSpawner;
    private TextMeshProUGUI _spawnCountText;

    void Start()
    {
        _spawnCountText = GetComponent<TextMeshProUGUI>();
    }

  void Update()
    {
        _spawnCountText.text = ObjectSpawner.SpawnedCounts + "/" + ObjectSpawner.SpawnLimit;
    }
}
