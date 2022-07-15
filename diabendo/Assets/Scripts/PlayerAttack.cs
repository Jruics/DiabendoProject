using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsPinhata;
    public float attackRange;
    public int damage;


    //Caso o jogador clicque na tecla, e iniciado o ataques
    void Update()
    {
//#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] pinhataToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPinhata);
                for (int i = 0; i < pinhataToDamage.Length; i++)
                {
                    Debug.Log("Pinhata:" + pinhataToDamage[i]);
                    Debug.Log("Pinhata Component:" + pinhataToDamage[i].GetComponent<Pinhata>());
                    pinhataToDamage[i].GetComponent<Pinhata>().TakeDamage(damage);
                    //Attack(pinhataToDamage, i);

                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }else
        {
            timeBtwAttack -= Time.deltaTime;
            
        }

//#endif
    }


    public void Attack(Collider2D[] pinhataToDamage, int i)
    {
        pinhataToDamage[i].GetComponent<Pinhata>().TakeDamage(damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
