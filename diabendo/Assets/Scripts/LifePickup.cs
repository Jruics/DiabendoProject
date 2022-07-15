using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour
{
    private LifeManager lifeSystem;

    public AudioSource lifePickupSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        lifeSystem = FindObjectOfType<LifeManager>();
    }

    //Caso o jogador entre na zona, da vida e apaga o objeto
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Character")
        {
            lifeSystem.GiveLife();
            lifePickupSoundEffect.Play();
            Destroy(gameObject);
        }
    }
}
