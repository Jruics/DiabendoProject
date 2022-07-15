using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    public int enemyHealth;

    public GameObject deathEffect;

    public int pointsToAdd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gere a vida dos inimigos
        if(enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.AddPoints(pointsToAdd);
            Destroy(gameObject);
        }
    }

    public void  giveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
    }
}
