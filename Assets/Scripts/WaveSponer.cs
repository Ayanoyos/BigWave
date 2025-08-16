using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum WaveType { Wave1, Wave2, Wave3 }

    [SerializeField] private GameObject wave1Prefab;
    [SerializeField] private GameObject wave2Prefab;
    [SerializeField] private GameObject wave3Prefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private Transform spawnPoint;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            WaveType randomType = (WaveType)Random.Range(0, System.Enum.GetValues(typeof(WaveType)).Length);
            SpawnWave(randomType);
        }
    }

    private void SpawnWave(WaveType type)
    {
        GameObject prefab = null;

        switch (type)
        {
            case WaveType.Wave1:
                prefab = wave1Prefab;
                break;
            case WaveType.Wave2:
                prefab = wave2Prefab;
                break;
            case WaveType.Wave3:
                prefab = wave3Prefab;
                break;
        }

        if (prefab != null)
        {
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
