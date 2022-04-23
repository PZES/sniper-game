using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public void mute(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
        
    }
    public void resetgame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("scope", 0);
        PlayerPrefs.SetInt("supressor", 0);
        PlayerPrefs.SetInt("stock", 0);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetInt("gun", 1);
        PlayerPrefs.Save();
    }
}
