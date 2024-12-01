using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class MainUI : MonoBehaviour
{   
    Player player;
    CombatManager combatManager;
    private int currentHealth;
    private int currentWave;
    private int enemiesLeft;
    private int currentPoints;
    Label Health;

    Label Wave;

    Label EnemiesLeft;
    Label Point;
    void Awake()
    {
        player = FindObjectOfType<Player>();
        if (player != null)
        {
            currentHealth = player.health.CurrentHealth;
        }
        
        combatManager = FindObjectOfType<CombatManager>();
        if (combatManager != null)
        {
            currentWave = combatManager.waveNumber;
            enemiesLeft = combatManager.totalEnemies;
            currentPoints = combatManager.totalPoints;
        }

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Health = root.Q<Label>("Health");
        Point = root.Q<Label>("Point");
        Wave = root.Q<Label>("Wave");
        EnemiesLeft = root.Q<Label>("EnemiesLeft");

        if (player != null)
        {
            Health.text = "Health: " + currentHealth;
        }

        if (combatManager != null)
        {
            Wave.text = "Wave: " + currentWave;
            EnemiesLeft.text = "Enemies Left: " + enemiesLeft;
            Point.text = "Points: " + currentPoints;
        }
    }

    void Update()
    {   
        if (player != null)
        {
            currentHealth = player.health.CurrentHealth;
            Health.text = "Health: " + currentHealth;
        }

        if (combatManager != null)
        {   
            currentWave = combatManager.waveNumber;
            enemiesLeft = combatManager.totalEnemies;
            currentPoints = combatManager.totalPoints;

            Wave.text = "Wave: " + currentWave;
            EnemiesLeft.text = "Enemies Left: " + enemiesLeft;
            Point.text = "Points: " + currentPoints;
        }
    }
}
