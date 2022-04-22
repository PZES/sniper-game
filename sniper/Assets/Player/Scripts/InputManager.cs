using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerLook look;
    public AudioSource shoot1;
    public AudioSource shoot2;
    public AudioSource shoot3;
    public GameObject pauseMenuUI;
    // Scoped Variables
    private bool isScoped = false;
    Animator animator;
    GameObject weaponHolder;
    GameObject scopeView;

    const float zoomPOV0 = 50f, zoomPOV1 = 40f, zoomPOV2 = 20f, zoomPOV3 = 10f, normalPOV = 60f;

    void Awake()
    {

        // Hide Cursor (PC Testing Purposes)
       // Cursor.lockState = CursorLockMode.Locked;


        // For Use by Look action
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        look = GetComponent<PlayerLook>();
        
        // Declare GO's for use of Scope action
        weaponHolder = GameObject.Find("weaponHolder");
        scopeView = GameObject.Find("ScopeView2");
        scopeView.SetActive(false);
        animator = weaponHolder.GetComponent<Animator>();
        
    }
    private void Start()
    {
        shoot1 = GetComponent<AudioSource>();
        shoot1.Play();
        shoot2 = GetComponent<AudioSource>();
        shoot2.Play();
        shoot3 = GetComponent<AudioSource>();
        shoot3.Play();
    }
    void Update()
    {
        // Scope Function
        if (onFoot.Scope.triggered)
        {
            isScoped = !isScoped;

            // Trigger "Scoped" animation
            animator.SetBool("Scoped", isScoped);

            // Delay Crosshairs and Gun Removal to account for "Scoped" Animation
            if(isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnscoped();
        }
        if (onFoot.Shoot.triggered)
        {
            Debug.Log("triggered");
            int gun = PlayerPrefs.GetInt("gun");
            switch (gun)
            {
                case 1:
                    Debug.Log("1");
                    shoot1.Play();
                    break;
                case 2:
                    Debug.Log("2");
                    shoot2.Play();
                    break;
                case 3:
                    Debug.Log("3");
                    shoot3.Play();
                    break;
            }
        }

        if (onFoot.Pause.triggered)
        {
            Debug.Log("paused");
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void OnUnscoped()
    {
        scopeView.SetActive(false);
        weaponHolder.SetActive(true);
        Camera.main.fieldOfView = normalPOV;
    }

    IEnumerator OnScoped()
    {
        // .15 seconds is the exact same duration of the "Scoped" animation in 
        //  the animation controller in Unity
        int stockLevel = PlayerPrefs.GetInt("stock");
        
        switch (stockLevel)
        {
            case 0:
                yield return new WaitForSeconds(.5f);
                Debug.Log("0");
                break;
            case 1:
                yield return new WaitForSeconds(.3f);
                Debug.Log("1");
                break;
            case 2:
                yield return new WaitForSeconds(.15f);
                Debug.Log("2");
                break;
            case 3:
                yield return new WaitForSeconds(.1f);
                Debug.Log("3");
                break;


        }
        scopeView.SetActive(true);
        weaponHolder.SetActive(false);
        int scopeLevel = PlayerPrefs.GetInt("scope");
        switch (scopeLevel)
        {
            case 0:
                Camera.main.fieldOfView = zoomPOV0;
                break;
            case 1:
                Camera.main.fieldOfView = zoomPOV1;
                break;
            case 2:
                Camera.main.fieldOfView = zoomPOV2;
                break;
            case 3:
                Camera.main.fieldOfView = zoomPOV3;
                break;


        }

    }

    // This calls look to adjust accordingly with player input
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    // These allow Look to work but idk what they do
    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
