using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    public Bullet bullet;
    public int damage;

     void OnTriggerEnter(Collider other)
    {
        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        if (hitbox != null)
        {
            hitbox.Damage(damage);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        var invincibilityComponent = collision.gameObject.GetComponent<InvincibilityComponent>();
        if (invincibilityComponent != null)
        {
            invincibilityComponent.StartInvincibility();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hitbox = collision.GetComponent<HitboxComponent>();
        
        if (collision.gameObject.tag == gameObject.tag)
        {
            Debug.Log("Same tag");
            return; // Prevent damage if the tags are the same
        }
        
        if (collision.CompareTag("Bullet"))
        {   
            if (hitbox != null)
            {   
                hitbox.Damage(collision.GetComponent<Bullet>());
            }
        }
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss" ) 
        {   
            if (hitbox != null)
            {
                hitbox.Damage(damage);
            }
        }
    }
}