using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        if (PlayerPrefs.GetInt("level") >= 2)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            //U have not completed previous levels 
        }
        
    }
    public void Level3()
    {
        if (PlayerPrefs.GetInt("level") >= 3)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            //U have not completed previous levels
        }
        
    }
}
