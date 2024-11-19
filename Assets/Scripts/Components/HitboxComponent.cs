using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HitboxComponent : MonoBehaviour
{
    public HealthComponent health;

    void Start()
    {
        health = GetComponent<HealthComponent>();
        if (health == null)
        {
            Debug.LogError("HealthComponent is missing!");
        }
    }

    public void Damage(Bullet bullet)
    {   

        if (health != null)
        {
            Debug.Log(bullet.damage + " damage from bullet.");
            health.Subtract(bullet.damage);
        }
    }

    public void Damage(int damage)
    {
        if (health != null)
        {
            health.Subtract(damage);
            Debug.Log("Player took " + damage + " damage form enemy.");
        }
    }
}
