using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
     
    }

    //Indica ao levelManager o ultimo checkpoint frequentado
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Character")
        {
            levelManager.currentCheckpoint = gameObject;
        }
    }
}
