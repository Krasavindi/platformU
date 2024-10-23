using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class rubiesText : MonoBehaviour
{

    TextMeshProUGUI rubyText;
    int ruby;
    int gems;
    

    // Start is called before the first frame update
    void Start()
    {
        

        
        
    }
    void Update()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Gem");
        gems = go.Length;
        ruby = gems;
        rubyText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    // Update is called once per frame
    private void UpdateDisplay()
    {
        rubyText.text = ruby.ToString();
        if (rubyText.text == "0")
        {
            Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
        }
    }
    // public int GetRubies()
    // {
    //     return ruby.ToString;
    // }
}
