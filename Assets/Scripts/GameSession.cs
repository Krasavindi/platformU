using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    // public float wg = 9.8f;
    // public float sg = -9.8f;
    // public float ag = -9.8f;
    // public float dg = 9.8f;

    int rubies = 0;
    int gems;
    int rubyCount;
    
    void Start()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Gem");
        gems = go.Length;
        //srubyCount = FindObjectOfType<rubiesText>().GetRubies(); 
    }

    void Update()
    {
        // if (gems < 1)
        // {
        //     Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
        // }
        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     Physics2D.gravity = new Vector2(0, wg);
        // }
        // else if (Input.GetKeyDown(KeyCode.S))
        // {
        //     Physics2D.gravity = new Vector2(0, sg);
        // }
        // else if (Input.GetKeyDown(KeyCode.A))
        // {
        //     Physics2D.gravity = new Vector2(ag, 0);
        // }
        // else if (Input.GetKeyDown(KeyCode.D))
        // {
        //     Physics2D.gravity = new Vector2(dg, 0);
        // }
    
    }
    public int GetGems()
    {
        return rubies;
    }
    public void TotalRubies(int rubin)
    {
        rubies += rubin;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
