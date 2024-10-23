using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 1f;
    [SerializeField] GameObject acorn;
    [SerializeField]float acornSpeed = 20f;
    [SerializeField] Transform hand;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource rubySound;
    [SerializeField] AudioSource loseSound;
    [SerializeField] AudioSource climbSound;
    [SerializeField] AudioSource shootSound;
    Transform reloadPlace;
    [SerializeField] float lives = 3;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;
    bool isAlive = true;
    
    
    void Start()
    {
        reloadPlace = FindObjectOfType<reload>().transform;
        transform.position = reloadPlace.transform.position;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    void Update()
    {
        if(!isAlive) { return;}
        Run();
        
        FlipSprite();

        Climb();
        
        Die();
        
        Bouncing();
    }
    
    public float Lives()
    {
        return lives;
    }
    private void Bouncing()
    {
        if(myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Bouncing")))
        {
            jumpSound.Play();
        }
    }

    void OnFire(InputValue value)
    {
        if(!isAlive) { return;}
        if(value.isPressed)
        {
        shootSound.Play();
        GameObject bullet = Instantiate(acorn, hand.position, Quaternion.identity);
        if(transform.localScale.x > 0)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(acornSpeed, 2);
        }
        if(transform.localScale.x < 0)
        {
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-acornSpeed, 2);
        } 
        }
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    
    void OnJump(InputValue value)
    {
        if(!isAlive) { return;}
        if(value.isPressed && myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            jumpSound.Play();
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    public bool GoNextLevel()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("LevelEntry")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity; 
    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        
        if(playerHasHorizontalSpeed)
        {
            myAnimator.SetBool("running", true);
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
            
        }
        else
        {
            myAnimator.SetBool("running", false);
        }
    }
    void Climb()
    {
        if(!isAlive) { return;}
        if(!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("climbing", false);
            return;
        }
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;
        
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        
        myAnimator.SetBool("climbing", playerHasVerticalSpeed);
        if(playerHasVerticalSpeed)
        {
            climbSound.Play();
        }
        else
        {
            climbSound.Stop();
        }
    }
    
    private void Die()
    {
        if(!isAlive) { return;}
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Spikes")) || myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Spikes")) )
        {
            loseSound.Play();
            myAnimator.SetBool("dying", true);
            myRigidbody.velocity = new Vector2(0, 3);
            myBodyCollider.enabled = false;
            myFeetCollider.enabled = false;
            
            isAlive = false;
            lives--;
           
            if(lives < 0)
            {
                Destroy(gameObject, 2);
                FindObjectOfType<GameSession>().GameOver();
            }
            else
            {
            transform.position = reloadPlace.position;
            myBodyCollider.enabled = true;
            myFeetCollider.enabled = true;
            isAlive = true;

            myAnimator.SetBool("dying", false);
            }
        }
    }
    private void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(Mathf.Sign(hand.localScale.x), 1f);
    }
    private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Gem")
            {
                rubySound.Play();
                FindObjectOfType<GameSession>().TotalRubies(1);
                
                Destroy(other.gameObject, 0.5f);
            }
            if(other.tag == "LevelEntry")
            {
                Destroy (gameObject);
                FindObjectOfType<GameSession>().LoadNextScene();
            }   
        }
}
