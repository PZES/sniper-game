using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinamount : MonoBehaviour
{

    public Text textelement;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.HasKey("money").ToString());
        textelement.text = PlayerPrefs.GetInt("money").ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
