using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinal : MonoBehaviour
{
    Rigidbody2D eBody;

    public GameObject HUD;
     
    public float moveBossSpeed;

    //public int damageToGive;


    // Start is called before the first frame update
    void Start()
    {
        eBody = this.GetComponent<Rigidbody2D> ();
       
        
    }


    // Update is called once per frame
    void Update()
    {
        //Codigo que movimenta o boss
         GetComponent<Rigidbody2D>().velocity = new Vector2(moveBossSpeed, GetComponent<Rigidbody2D>().velocity.y);   
    }

    //Funcao para detetar se colide com o chão ou com o jogador, caso colida com o chão é-lhe dada mais velocidade, caso colida
    //com o jogador é-lhe retirada uma vida
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            Debug.Log("Hit the Ground");
            eBody.velocity = new Vector2(0, 2) * Time.deltaTime;
            //eBody.velocity = new Vector2(0, 2);
            eBody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }

        if (other.tag == "Player")
        {
            // Retira uma vida ao Player
            HUD.GetComponent<LifeManager>().TakeLife();
            Debug.Log("Hit player, " + other);
        }
    }
}
