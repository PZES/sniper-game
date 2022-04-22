using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScope : MonoBehaviour
{

    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    void Start()
    {
        int gun = PlayerPrefs.GetInt("gun");
        switch (gun)
        {
            case 1:
                Debug.Log("1");
                gun1.SetActive(true);
                gun2.SetActive(false);
                gun3.SetActive(false);
                break;
            case 2:
                Debug.Log("2");
                gun1.SetActive(false);
                gun2.SetActive(true);
                gun3.SetActive(false);
                break;
            case 3:
                Debug.Log("3");
                gun1.SetActive(false);
                gun2.SetActive(false);
                gun3.SetActive(true);
                break;
        }
    }
}
