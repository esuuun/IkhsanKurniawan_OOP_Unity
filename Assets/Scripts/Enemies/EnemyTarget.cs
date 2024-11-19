using UnityEngine;

public class EnemyTarget : Enemy
{
    public float speed = 5f;
    private Vector2 screenBounds;
    private Transform player;

    private AttackComponent attackComponent;
    void Start()
    {   
        attackComponent = GetComponent<AttackComponent>();
        // Initialize enemy level or other properties if needed
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpawnFromRandomSide();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.isKinematic = true; // Ensure the enemy is not affected by physics
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.freezeRotation = true; // Prevent rotation
    }

    void Update()
    {
        // Update enemy behavior if needed
        MoveTowardsPlayer();
    }

    void SpawnFromRandomSide()
    {
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        // Always spawn from the top
        transform.position = new Vector2(randomX, screenBounds.y);
        speed = Mathf.Abs(speed); // Ensure speed is positive to move downwards
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}