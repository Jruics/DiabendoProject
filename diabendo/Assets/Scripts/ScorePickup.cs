using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public int pointsToAdd;

    //Ao colidir com o objeto, da pontos e apaga-o
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>() == null)
        {
            return;
        }
        else
        {
            ScoreManager.AddPoints(pointsToAdd);

            Destroy(gameObject);
        }
    }
}
