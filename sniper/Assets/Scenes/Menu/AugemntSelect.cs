using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AugemntSelect : MonoBehaviour
{
    public GameObject scope1_img;
    public GameObject scope2_img;
    public GameObject scope3_img;
    public GameObject supressor1_img;
    public GameObject supressor2_img;
    public GameObject supressor3_img;
    public GameObject stock1_img;
    public GameObject stock2_img;
    public GameObject stock3_img;
    private void Update()
    {
        int scope = PlayerPrefs.GetInt("scope");
        int supressor = PlayerPrefs.GetInt("supressor");
        int stock = PlayerPrefs.GetInt("stock");
        if (scope >= 3)
        {
            scope3_img.SetActive(true);
        }
        if (scope >= 2)
        {
            scope2_img.SetActive(true);
        }
        if(scope >= 1)
        {
            scope1_img.SetActive(true);
        }
        if (supressor >= 3)
        {
            supressor3_img.SetActive(true);
        }
        if (supressor >= 2)
        {
            supressor2_img.SetActive(true);
        }
        if (supressor >= 1)
        {
            supressor1_img.SetActive(true);
        }
        if (stock >= 3)
        {
            stock3_img.SetActive(true);
        }
        if (stock >= 2)
        {
            stock2_img.SetActive(true);
        }
        if (stock >= 1)
        {
            stock1_img.SetActive(true);
        }
    }
    public void SetScope1()
    {

        int coins = PlayerPrefs.GetInt("money");
        //If scope level is 0 
        if (PlayerPrefs.GetInt("scope") == 0)
        {
            //If you have enough coins
            if (coins >= 1)
            {
                 
                PlayerPrefs.SetInt("scope", 1);
                PlayerPrefs.SetInt("money", coins - 1);
                scope1_img.SetActive(true);
                PlayerPrefs.Save();
            }
            else
            {
                Debug.Log("no money");
                //U dont got enough money
            }
        }
        else
        {
            //print that u have already bought this 
        }
    }
    public void SetScope2()
    {
        int coins = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("scope") == 2)
        {
            //you have already bought this
        }
        else if (PlayerPrefs.GetInt("scope") == 1)
        {
            if(coins >= 3)
            {
                PlayerPrefs.SetInt("scope", 2);
                PlayerPrefs.SetInt("money", coins - 3);
                scope2_img.SetActive(true);
                PlayerPrefs.Save();
            }
            else
            {
                //U dont got enough money
            }
            
        }
        else
        {
            //print that u have not bought scope 1
        }
            
    }
    public void SetScope3()
    {
        int coins = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("scope") == 3)
        {
            //you have already bought this
        }
        else if (PlayerPrefs.GetInt("scope") == 2)
        {
            if (coins >= 5)
            {
                PlayerPrefs.SetInt("scope", 3);
                PlayerPrefs.SetInt("money", coins - 5);
                scope3_img.SetActive(true);
                PlayerPrefs.Save();
            }
            else
            {
                //U dont got enough money
            }

        }
        else
        {
            //print that u have not bought previous
        }

    }
    public void SetSupressor1()
    {
        int coins = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("supressor") == 0)
        {
            if (coins >= 1)
            {
                PlayerPrefs.SetInt("supressor", 1);
                PlayerPrefs.SetInt("money", coins - 1);
                supressor1_img.SetActive(true);
                PlayerPrefs.Save();
            }
            else
            {
                //U dont got enough money
            }
        }
        else
        {
            //print that u have already bought this 
        }
    }
    public void SetSupressor2()
    {
        int coins = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("supressor") == 2)
        {
            //you have already bought this
        }
        else if (PlayerPrefs.GetInt("supressor") == 1)
        {
            
            if (coins >= 3)
            {
                PlayerPrefs.SetInt("supressor", 2);
                PlayerPrefs.SetInt("money", coins - 3);
                supressor2_img.SetActive(true);
                PlayerPrefs.Save();
            }
            else
            {
                //U dont got enough money
            }
        }
        else
        {
            //print that u have not bought previous
        }
    }
    public void SetSupressor3()
    {
        int coins = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("supressor") == 3)
        {
            //you have already bought this
        }
        else if (PlayerPrefs.GetInt("supressor") == 2)
        {

            if (coins >= 5)
            {
                PlayerPrefs.SetInt("supressor", 3);
                PlayerPrefs.SetInt("money", coins - 5);
                supressor3_img.SetActive(true);
                PlayerPrefs.Save();
            }
            else
            {
                //U dont got enough money
            }
        }
        else
        {
            //print that u have not previous
        }
    }
    public void SetStock1()
    {
        int coins = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("stock") == 0)
        {
            if (coins >= 1)
            {
                PlayerPrefs.SetInt("stock", 1);
                PlayerPrefs.SetInt("money", coins - 1);
                stock1_img.SetActive(true);
                PlayerPrefs.Save();
            }
            else
            {
                //U dont got enough money
            }
        }
        else
        {
            //print that u have already bought this 
        }
    }
    public void SetStock2()
    {
        int coins = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("stock") == 2)
        {
            //you have already bought this
        }
        else if (PlayerPrefs.GetInt("stock") == 1)
        {

            if (coins >= 3)
            {
                PlayerPrefs.SetInt("stock", 2);
                PlayerPrefs.SetInt("money", coins - 3);
                stock2_img.SetActive(true);
                PlayerPrefs.Save();
            }
            else
            {
                //U dont got enough money
            }
        }
        else
        {
            //print that u have not bought previous
        }
    }
    public void SetStock3()
    {
        int coins = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("stock") == 3)
        {
            //you have already bought this
        }
        else if (PlayerPrefs.GetInt("stock") == 2)
        {

            if (coins >= 5)
            {
                PlayerPrefs.SetInt("stock", 3);
                PlayerPrefs.SetInt("money", coins - 5);
                stock3_img.SetActive(true);
                PlayerPrefs.Save();
            }
            else
            {
                //U dont got enough money
            }
        }
        else
        {
            //print that u have not previous
        }
    }
}
