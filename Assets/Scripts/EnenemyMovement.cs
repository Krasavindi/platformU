using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.VFX;

public class EnenemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
    BoxCollider2D myFrontCollider;
    Animator death;
    [SerializeField] AudioSource deathSound;

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
        myRigidBody.velocity = new Vector2(-moveSpeed, 0);
        Die();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
      moveSpeed = -moveSpeed;
      FlipEnemyFacing();
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
            deathSound.Play();
            death.SetBool("isDying", true);
            
            Destroy(gameObject, 0.5f);
        }
    }
}
