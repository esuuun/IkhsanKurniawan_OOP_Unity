using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Animator animator;

    public static Player instance { get; private set; }
    HealthComponent health;

    HitboxComponent hitbox;
    
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        hitbox = GetComponent<HitboxComponent>();
        
        animator= GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {      
        health = GetComponent<HealthComponent>();
        
        hitbox = GetComponent<HitboxComponent>(); 

        if (instance == null)
        {   
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        animator.SetBool("isMoving", playerMovement.IsMoving());
    }
}
