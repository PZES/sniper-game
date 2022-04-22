using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenus : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pauseMenuUI;
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    public void Start()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        //pauseMenuUI.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("test");
        if(onFoot.Pause.triggered)
        {
            Debug.Log("triggered");
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }


}
