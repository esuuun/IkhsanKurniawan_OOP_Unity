using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HitboxComponent : MonoBehaviour
{
    public HealthComponent health;
    private InvincibilityComponent invincibilityComponent;

    void Start()
    {
        health = GetComponent<HealthComponent>();
        invincibilityComponent = GetComponent<InvincibilityComponent>();
        if (health == null)
        {
            Debug.LogError("HealthComponent is missing!");
        }
    }

    public void Damage(Bullet bullet)
    {   
        if(invincibilityComponent == null || !invincibilityComponent.isInvincible){
            if (health != null)
            {
                Debug.Log(bullet.damage + " damage from bullet.");
                health.Subtract(bullet.damage);
                invincibilityComponent.StartInvincibility();
            }
        }
    }

    public void Damage(int damage)
    {
        if (invincibilityComponent == null || !invincibilityComponent.isInvincible ) { 
            if (health != null){
                health.Subtract(damage);
                invincibilityComponent.StartInvincibility();
                Debug.Log("Player took " + damage + " damage form enemy.");
            }
        }   
    }
}
