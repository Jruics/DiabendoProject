using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinishedParticle : MonoBehaviour
{
    private ParticleSystem thisParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        //Encontra a particula na cena
        thisParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se a particula estiver a "tocar" ignora-a
        //Quando acaba destroi-a
        if (thisParticleSystem.isPlaying)
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
