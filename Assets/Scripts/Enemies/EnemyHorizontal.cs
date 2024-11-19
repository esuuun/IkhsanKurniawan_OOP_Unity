using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed = 5f;
    private Vector2 screenBounds;
    private AttackComponent attackComponent;

    void Start()
    {   
        attackComponent = GetComponent<AttackComponent>();
        
        // Initialize enemy level or other properties if needed
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpawnFromRandomSide();
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