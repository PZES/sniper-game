using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelect : MonoBehaviour
{
    public GameObject gun1_pic;
    public GameObject gun2_pic;
    public GameObject gun3_pic;
    private void Start()
    {
        gun1_pic.SetActive(true);
    }
    public void SetGun1()
    {
        PlayerPrefs.SetInt("gun", 1);
        gun1_pic.SetActive(true);
        gun2_pic.SetActive(false);
        gun3_pic.SetActive(false);
        //Debug.Log("1");
    }
    public void SetGun2()
    {
        PlayerPrefs.SetInt("gun", 2);
        gun1_pic.SetActive(false);
        gun2_pic.SetActive(true);
        gun3_pic.SetActive(false);
        //Debug.Log("2");
    }
    public void SetGun3()
    {
        PlayerPrefs.SetInt("gun", 3);
        gun1_pic.SetActive(false);
        gun2_pic.SetActive(false);
        gun3_pic.SetActive(true);
        //Debug.Log("3");
    }
}
