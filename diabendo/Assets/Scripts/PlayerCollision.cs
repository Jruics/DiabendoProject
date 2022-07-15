using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
     public string levelToLoad;

    //Ao colidir com o objeto carrega o nivel
    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Nivel Seguinte");

        SceneManager.LoadScene(levelToLoad);

    }
}
