using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelect : MonoBehaviour
{
    public void SetGun1()
    {
        PlayerPrefs.SetInt("gun", 1);
        Debug.Log("1");
    }
    public void SetGun2()
    {
        PlayerPrefs.SetInt("gun", 2);
        Debug.Log("2");
    }
    public void SetGun3()
    {
        PlayerPrefs.SetInt("gun", 3);
        Debug.Log("3");
    }
}
