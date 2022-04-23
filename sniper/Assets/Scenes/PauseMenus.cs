using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenus : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pauseMenuUI;
    public GameObject winUI;
    public GameObject loseUI;


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Debug.Log("Quit");
        Application.Quit();
    }
    // Update is called once per frame
    public void Win(int points)
    {
        Time.timeScale = 0f;
        winUI.SetActive(true);
        Debug.Log(PlayerPrefs.GetInt("level") + "before");
        int level = PlayerPrefs.GetInt("level")+1;
        points += PlayerPrefs.GetInt("money");
        Debug.Log(level + "level");
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("money", points);
        PlayerPrefs.Save();
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        loseUI.SetActive(true);
    }

    public void nextLevel()
    {
        Time.timeScale = 1f;
        winUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void restart()
    {
        Time.timeScale = 1f;
        loseUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
