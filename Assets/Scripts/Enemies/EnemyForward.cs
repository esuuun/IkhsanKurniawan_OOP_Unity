using UnityEngine;

public class EnemyForward : Enemy
{
    public float speed = 5f;
    private Vector2 screenBounds;

    void Start()
    {
        // Initialize enemy level or other properties if needed
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpawnFromRandomSide();
    }

    void Update()
    {
        // Update enemy behavior if needed
        Move();
    }

    void SpawnFromRandomSide()
    {
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        // Always spawn from the top
        transform.position = new Vector2(randomX, screenBounds.y);
        speed = Mathf.Abs(speed); // Ensure speed is positive to move downwards
    }

    void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -screenBounds.y)
        {
            SpawnFromRandomSide();
        }
    }

}