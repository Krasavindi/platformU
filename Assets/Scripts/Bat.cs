using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Bat : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;
    [SerializeField] List<Transform> waypoints2;
    [SerializeField] float flyingSpeed = 1f;
    [SerializeField] float timeBeforeFly = 5f;
    Rigidbody2D myRigidBody;
    BoxCollider2D myBoxCollider;
    Animator betAnimator; 
    bool isBack = false;
    
    
    int waypointIndex = 0;
    int waypointIndex2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        betAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        waypointIndex = 0;
        

    }

    // Update is called once per frame
    private void Update() 
    {
         StartCoroutine(MoveEnemy());
    }

    
    

    IEnumerator MoveEnemy(){
        
        
        yield return new WaitForSeconds(timeBeforeFly);
        betAnimator.SetBool("flying", true);
        
        if(waypointIndex <= waypoints.Count - 1)
        {
            
            betAnimator.SetBool("flying", true);
            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = flyingSpeed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
            
           }
        else 
        {
            betAnimator.SetBool("flying", false);
        }  
        
    }

        
    
   
        
}
