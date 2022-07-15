using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour
{
    //Dano a dar ao jogador e som a tocar
    public int damageToGive;
    public AudioSource hurtSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Caso o jogador colida, da-le dano, empurra-o e toca o som
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Character")
        {
            HealthManager.HurtPlayer(damageToGive);
            hurtSoundEffect.Play();

            var player = other.GetComponent<PlayerController>();
            player.knockbackCount = player.knockbackLength;
            
            if(other.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
            }
            else
            {
                player.knockFromRight = false;
            }
        }
    }
}
