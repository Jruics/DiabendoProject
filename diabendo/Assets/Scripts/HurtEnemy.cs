using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    //Indica o dano que o inimigo vai levar
    public int damageToGive;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Caso o inimigo colida, da-lhe dano
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pinhata")
            other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
    }
}
