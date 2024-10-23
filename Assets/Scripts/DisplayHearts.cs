using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHearts : MonoBehaviour
{
    private PlayerMovement playerScript;
    private float lives;
    public GameObject[] prefHearts; //сюда в инспекторе добавляем GameObject-ы сердечек
 
 
    void Start () {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); //получаем контроллер игрока для дальнейшей работы
    }
    
    void Update () {
        lives = playerScript.Lives(); //кол-во жизней в текущий момент
 
        if (lives > 2)
        {
            prefHearts[0].SetActive(true);
            prefHearts[1].SetActive(true);
            prefHearts[2].SetActive(true);
        }
        else if (lives == 2)
        {
            prefHearts[1].SetActive(false);
        }
        if (lives >= 1  && lives < 2)
        {
            prefHearts[0].SetActive(false);
        }
        if(lives < 1)
        {
            prefHearts[2].SetActive(false);
        }

    }
}
