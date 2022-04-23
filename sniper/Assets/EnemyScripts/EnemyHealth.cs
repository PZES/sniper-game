using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    public float enemyHealth = 100f;

    public void DeductHealth(float deductHealth)
    {
        enemyHealth -= deductHealth;

        if(enemyHealth <= 0)
        {
            EnemyDead();
        }
    }

    public void EnemyDead()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
