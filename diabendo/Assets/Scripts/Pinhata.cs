using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pinhata : MonoBehaviour
{
    public int health;
  
    public float speed;

    private Animator anim;
    public GameObject bloodEffect;
    public GameObject bossHealthBar;

    public int pointsToAdd;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);

    }

    // Caso a pinhata seja derrotada, retira a barra do ecra e dá pontos
    void Update()
    {
        if(health <= 0)
        {
            bossHealthBar.SetActive(false);
            ScoreManager.AddPoints(pointsToAdd);
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    //Ao levar dano inicia a particula correta
    public void TakeDamage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage TAKEN !");
    }     
}
