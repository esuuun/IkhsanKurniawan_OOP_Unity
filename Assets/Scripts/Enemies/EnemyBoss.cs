using UnityEngine;

public class EnemyBoss : Enemy
{
    public float speed = 5f;
    private Vector2 screenBounds;
    public Weapon weapon;
    [SerializeField] private float shootSpeedInterval = 1f; 

    private AttackComponent attackComponent;
    void Start()
    {   
        attackComponent = GetComponent<AttackComponent>(); 
        // Initialize enemy level or other properties if needed
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpawnFromRandomSide();
        if (weapon != null)
        {
            weapon = Instantiate(weapon, transform);
            weapon.transform.localPosition = new Vector3(0, -0.67f, 0); // Move the weapon downwards
            weapon.transform.localRotation = Quaternion.Euler(0, 0, 180); // Rotate the weapon 180 degrees
            weapon.shootIntervalInSeconds = shootSpeedInterval; // Set the shoot interval based on shoot speed
        }
    }

    void Update()
    {
        // Update enemy behavior if needed
        Move();
        CheckBoundsAndReverse();
    }

    void SpawnFromRandomSide()
    {
        float randomY = Random.Range(-screenBounds.y, screenBounds.y);
        if (Random.value > 0.5f)
        {
            // Spawn from the left
            transform.position = new Vector2(-screenBounds.x, randomY);
        }
        else
        {
            // Spawn from the right
            transform.position = new Vector2(screenBounds.x, randomY);
            speed = -speed; // Move to the left
        }
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void CheckBoundsAndReverse()
    {
        if (transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x)
        {
            speed = -speed; // Reverse direction
        }
    }
}