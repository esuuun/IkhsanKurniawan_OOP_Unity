using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public int Level;

    public CombatManager combatManager;
    public EnemySpawner enemySpawner;

    private void OnDestroy()
    {

        if (enemySpawner != null && combatManager != null)
        {
            enemySpawner.onDeath();
            combatManager.onDeath();

        }

    }

    void Start()
    {
        // Initialize enemy level or other properties if needed
    }

    void Update()
    {
        // Update enemy behavior if needed
    }
}