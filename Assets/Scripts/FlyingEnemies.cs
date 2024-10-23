using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemies : MonoBehaviour
{
    WaveConfig waveConfiguration;
    List<Transform> waypoints;
    
    int waypointIndex = 0;
    
    
    void Start()
    {
        waypoints = waveConfiguration.GetWavepoint();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        waveConfiguration = waveConfig;
    }
    private void MoveEnemy()
    {
        if(waypointIndex <= waypoints.Count - 1)
        {
            
            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = waveConfiguration.GetmoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }

        
    }
}
