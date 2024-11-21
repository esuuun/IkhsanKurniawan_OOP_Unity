using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;


    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;


    public CombatManager combatManager;


    public bool isSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (totalKill >= minimumKillsToIncreaseSpawnCount)
        {
            totalKill = 0;
            spawnCountMultiplier += multiplierIncreaseCount;
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (isSpawning)
            {
                for (int i = 0; i < defaultSpawnCount * spawnCountMultiplier; i++)
                {
                    Instantiate(spawnedEnemy, transform.position, transform.rotation);
                    spawnCount++;
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public int spawn(int waveNumber)
    {
        int enemiesSpawned = defaultSpawnCount * spawnCountMultiplier;
        for (int i = 0; i < enemiesSpawned; i++)
        {
            Instantiate(spawnedEnemy, transform.position, transform.rotation);
            spawnCount++;
        }
        return enemiesSpawned;
    }
}
