using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthToGive;

    public AudioSource healthPickupSoundEffect;

    //public AudioSource pickupSound;

    //Verifica se colide com o jogador
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.GetComponent<PlayerController>() == null)
        {
            return;
        }
        else
        {
            //Caso colida, cura-o e apaga o objeto
            HealthManager.HurtPlayer(-healthToGive);

            //pickupSound.Play();
            //other.GetComponent<AudioSource>().Play();

            healthPickupSoundEffect.Play();
            Destroy(gameObject);
        }
    }
}
