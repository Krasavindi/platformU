using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    void Start()
    {
        
    }
    
        private void OnCollisionEnter2D(Collision2D other) 
        {
            
            if(other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<EnenemyMovement>().DamageDealer(1);
                
                Destroy(gameObject);
            }
            if(other.gameObject.tag == "BackEnemy")
            {
                other.gameObject.GetComponent<BackEnenemyMovement>().DamageDealer(1);
                Destroy(gameObject);
            }
            if(other.gameObject.tag == "platform")
            {
                Destroy(gameObject);
            }
            
            else 
            { 
               return; 
            }
            
        }
        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //     if(other.tag == "Enemy")
        //     {
        //         other.GetComponent<EnenemyMovement>().DamageDealer(1);
        //         Destroy(gameObject);
        //     }
        // }
        
        
    
}
