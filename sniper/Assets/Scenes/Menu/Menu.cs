using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("money"))
        {
            PlayerPrefs.SetInt("scope", 0);
            PlayerPrefs.SetInt("supressor", 0);
            PlayerPrefs.SetInt("stock", 0);
            PlayerPrefs.SetInt("money", 0);
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.SetInt("gun", 1);
            
        }
        
        PlayerPrefs.Save();
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
