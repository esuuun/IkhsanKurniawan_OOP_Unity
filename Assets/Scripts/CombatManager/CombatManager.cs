using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public float timer = 0;
    [SerializeField] private float waveInterval = 5f;
    public int waveNumber = 1;
    public int totalEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(waveInterval);
            SpawnEnemies();
            waveNumber++;
        }
    }

    private void SpawnEnemies()
    {
        foreach (var spawner in enemySpawners)
        {
            totalEnemies += spawner.spawn(waveNumber);
        }
    }
}
