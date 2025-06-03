using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;

    [SerializeField] private int waveNumber;
    [SerializeField] private List<Waves> waves;

    [System.Serializable]
    public class Waves
    {
        public GameObject prefab;
        public float spwanTimer;
        public float spwanInterval;
        public int objectsPerWaves;
        public int spawnedObjectCount;
    }
    // Update is called once per frame
    void Update()
    {
        waves[waveNumber].spwanTimer += Time.deltaTime * PlayerController.instance.boast;
        if (waves[waveNumber].spwanTimer >= waves[waveNumber].spwanInterval)
        {
            waves[waveNumber].spwanTimer = 0;
            SpawnObject();
        }
        if (waves[waveNumber].spawnedObjectCount >= waves[waveNumber].objectsPerWaves)
        {
            waves[waveNumber].spawnedObjectCount = 0;
            waveNumber++;
            if (waveNumber >= waves.Count)
            {
                waveNumber = 0; // Reset to the first wave if all waves have been spawned
            }
        }
    }

    private void SpawnObject()
    {
        Instantiate(waves[waveNumber].prefab, SpawnPosition(), transform.rotation);
        waves[waveNumber].spawnedObjectCount++;
    }

    private Vector2 SpawnPosition()
    {
        Vector2 spawnPos;

        spawnPos.x = minPos.position.x;
        spawnPos.y = Random.Range(minPos.position.y, maxPos.position.y);

        return spawnPos;

    }
}
