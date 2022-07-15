using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public bool playerInZone;

    public string levelToLoad;

    public string levelTag;
    // Start is called before the first frame update
    void Start()
    {
        //Bool para ver se o jogador esta na zona
        playerInZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Se o jogador estiver na zona e premir a tecla certa
        //A cena correta é carregada
        if(Input.GetKeyDown(KeyCode.S) && playerInZone)
        {
            PlayerPrefs.SetInt(levelTag, 1);
            Application.LoadLevel(levelToLoad);
        }
    }

    public void LoadLevel()
    {
        Application.LoadLevel(levelToLoad);
    }

    //Altera o bool para true ou false conforme o jogador
    //entrar e sair da area
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Character")
        {
            playerInZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Character")
        {
            playerInZone = false;
        }
    }
}
