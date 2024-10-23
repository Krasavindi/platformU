using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.VFX;

public class BossEnenemy : MonoBehaviour
{
    
    
    [Header ("Laser")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float enemyLaserSpeed = 10f;
    [SerializeField] Transform laser1;
    [SerializeField] Transform laser2;
    [SerializeField] Transform laser3;
    [SerializeField] Transform laser4;
    [SerializeField] Transform laser5;
    [SerializeField] Transform laser6;
    [SerializeField] AudioClip laserSound;
    [SerializeField] [Range(0,1)]float laserSoundVolume = 0.5f;

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        
    }
     void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        if(transform.localScale.x > 0)
        {
        GameObject enemyLaser = Instantiate(enemyLaserPrefab, laser1.transform.position, Quaternion.identity) as GameObject;
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyLaserSpeed, 0);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser, 3);

        GameObject enemyLaser2 = Instantiate(enemyLaserPrefab, laser2.transform.position, Quaternion.identity) as GameObject;
        enemyLaser2.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyLaserSpeed, 5);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser2, 3);

        GameObject enemyLaser3 = Instantiate(enemyLaserPrefab, laser3.transform.position, Quaternion.identity) as GameObject;
        enemyLaser3.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyLaserSpeed, -5);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser3, 3);

        GameObject enemyLaser4 = Instantiate(enemyLaserPrefab, laser4.transform.position, Quaternion.identity) as GameObject;
        enemyLaser4.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyLaserSpeed, 5);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser4, 3);

        GameObject enemyLaser5 = Instantiate(enemyLaserPrefab, laser5.transform.position, Quaternion.identity) as GameObject;
        enemyLaser5.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyLaserSpeed, 0);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser5, 3);

        GameObject enemyLaser6 = Instantiate(enemyLaserPrefab, laser6.transform.position, Quaternion.identity) as GameObject;
        enemyLaser6.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyLaserSpeed, -5);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser6, 3);
        }
        if(transform.localScale.x < 0)
        {
        GameObject enemyLaser = Instantiate(enemyLaserPrefab, laser1.transform.position, Quaternion.identity) as GameObject;
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyLaserSpeed, 0);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser, 3);

        GameObject enemyLaser2 = Instantiate(enemyLaserPrefab, laser2.transform.position, Quaternion.identity) as GameObject;
        enemyLaser2.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyLaserSpeed, 5);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser2, 3);

        GameObject enemyLaser3 = Instantiate(enemyLaserPrefab, laser3.transform.position, Quaternion.identity) as GameObject;
        enemyLaser3.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyLaserSpeed, -5);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser3, 3);

        GameObject enemyLaser4 = Instantiate(enemyLaserPrefab, laser4.transform.position, Quaternion.identity) as GameObject;
        enemyLaser4.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyLaserSpeed, 5);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser4, 3);

        GameObject enemyLaser5 = Instantiate(enemyLaserPrefab, laser5.transform.position, Quaternion.identity) as GameObject;
        enemyLaser5.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyLaserSpeed, 0);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser5, 3);

        GameObject enemyLaser6 = Instantiate(enemyLaserPrefab, laser6.transform.position, Quaternion.identity) as GameObject;
        enemyLaser5.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyLaserSpeed, -5);
        AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
        Destroy(enemyLaser6, 3);
            
        }
        
    }



}
