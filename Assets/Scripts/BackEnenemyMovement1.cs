using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.VFX;

public class BackEnenemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidBody;
    BoxCollider2D myFrontCollider;
    Animator death;

    [SerializeField] float health = 3;
    //[SerializeField] VisualEffect deathVFX;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myFrontCollider = GetComponent<BoxCollider2D>();
        death = GetComponent<Animator>();
    }

    
    void Update()
    {
        
        myRigidBody.velocity = new Vector2(moveSpeed, 0);
        Die();
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      moveSpeed = -moveSpeed;
      transform.localScale = new Vector2(Mathf.Sign(moveSpeed), 1f);
      //FlipEnemyFacing();
    }

    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        
    }
    public float GetHealth()
    {
        return health;
    }

    public void DamageDealer(float damage)
    {
        health -= damage;
    }
    private void Die()
    {
        if (health <= 0)
        {
            
            death.SetBool("isDying", true);
            Destroy(gameObject, 0.5f);
        }
    }
}
