using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{

    public GameObject greyout2;
    public GameObject greyout3;
    public GameObject lock2;
    public GameObject lock3;
    private void Update()
    {
        int level = PlayerPrefs.GetInt("level");
        Debug.Log(level);
        switch (level)
        {
            case 1:
                greyout2.SetActive(true);
                greyout3.SetActive(true);
                lock2.SetActive(true);
                lock3.SetActive(true);
                break;
            case 2:
                greyout2.SetActive(false);
                greyout3.SetActive(true);
                lock2.SetActive(false);
                lock3.SetActive(true);
                break;
            case 3:
                greyout2.SetActive(false);
                greyout3.SetActive(false);
                lock2.SetActive(false);
                lock3.SetActive(false);
                break;
        }
    }
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
