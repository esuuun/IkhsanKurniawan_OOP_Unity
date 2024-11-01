using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovement playerMovement;
    public Animator animator;

    public static Player instance { get; private set; }
    

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        animator= GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
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
