using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundsArray : MonoBehaviour
{
    public AudioSource shoot1;
    public AudioSource shoot2;
    public AudioSource shoot3;
    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float waitTimeCountdown = -1f;

    private void Start()
    {

        shoot2 = GetComponent<AudioSource>();
        //shoot2.Play();
        shoot3 = GetComponent<AudioSource>();
        //shoot3.Play();
        shoot1 = GetComponent<AudioSource>();
        //shoot1.Play();
    }

    void Update()
    {
        if (!shoot1.isPlaying || !shoot2.isPlaying || !shoot3.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
                float sound = Random.Range(1, 3);
                if(sound == 1)
                {
                    shoot1.Play();
                }
                else if(sound == 2)
                {
                    shoot2.Play();
                }
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }
}
