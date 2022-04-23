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
    public AudioSource audiotest;
    public Camera fpsCam;
    //public GameObject zombie;
    public GameObject pauseMenuUI;
    public GameObject pauseMenu;
    // Scoped Variables
    private bool isScoped = false;
    Animator animator;
    GameObject weaponHolder;
    GameObject scopeView;
    private int zom =0;
    private int tokens = 0;
    const float zoomPOV0 = 50f, zoomPOV1 = 40f, zoomPOV2 = 20f, zoomPOV3 = 10f, normalPOV = 60f;
    public float enemyDamage = 100f;
    private int i = 1;
    public GameObject zombie1;
    public GameObject zombie2;
    public GameObject zombie3;
    void Awake()
    {
        Time.timeScale = 0f;
        Time.timeScale = 1f;
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
        
        
        audiotest = GetComponent<AudioSource>();
        audiotest.Play();
        shoot2 = GetComponent<AudioSource>();
        //shoot2.Play();
        shoot3 = GetComponent<AudioSource>();
        //shoot3.Play();
        shoot1 = GetComponent<AudioSource>();
        //shoot1.Play();

    }
    void Update()
    {
        // Scope Function
        if(zom >= 3 && i == 1)
        {
            i = 2;
            pauseMenu.GetComponent<PauseMenus>().Win(tokens);
        }
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
            //Debug.Log("triggered");
            shoot();
            
            int gun = PlayerPrefs.GetInt("gun");
            switch (gun)
            {
                case 1:
                    //Debug.Log("1");
                    shoot1.Play();
                    break;
                case 2:
                    //Debug.Log("2");
                    shoot2.Play();
                    break;
                case 3:
                    //Debug.Log("3");
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
    void shoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.tag);
            if(hit.transform.tag == "Head")
            {
                EnemyHealth health = hit.transform.GetComponentInParent<EnemyHealth>();
                health.EnemyDead();
                tokens += 3;
                Debug.Log(tokens);
                zom++;
            }else if (hit.transform.tag == "Zombie")
            {
                EnemyHealth health = hit.transform.GetComponent<EnemyHealth>();
                health.DeductHealth(enemyDamage);
                tokens += 2;
                Debug.Log(tokens);
                zom++;
            }else if (hit.transform.tag == "ShootZone")
            {
                EnemyAI health = hit.transform.GetComponentInParent<EnemyAI>();
                health.OnAware();
            }
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
        int gun = PlayerPrefs.GetInt("gun");
        switch (scopeLevel)
        {
            case 0:
                if (gun == 1)
                {
                    Camera.main.fieldOfView = 50f;
                }else if(gun == 2)
                {
                    Camera.main.fieldOfView = 40f;
                }
                else
                {
                    Camera.main.fieldOfView = 55f;
                }
                
                break;
            case 1:
                if (gun == 1)
                {
                    Camera.main.fieldOfView = 40f;
                }
                else if (gun == 2)
                {
                    Camera.main.fieldOfView = 30f;
                }
                else
                {
                    Camera.main.fieldOfView = 50f;
                }
                break;
            case 2:
                if (gun == 1)
                {
                    Camera.main.fieldOfView = 30f;
                }
                else if (gun == 2)
                {
                    Camera.main.fieldOfView = 20f;
                }
                else
                {
                    Camera.main.fieldOfView = 40f;
                }
                break;
            case 3:
                if (gun == 1)
                {
                    Camera.main.fieldOfView = 20f;
                }
                else if (gun == 2)
                {
                    Camera.main.fieldOfView = 10f;
                }
                else
                {
                    Camera.main.fieldOfView = 30f;
                }
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
