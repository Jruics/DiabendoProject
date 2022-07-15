using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    //public int startingLives;

    private int lifeCounter;

    private Text theText;

    public GameObject gameOverScreen;

    public PlayerController character;

    public string levelToLoad;

    public float waitAfterGameOver;

    // Start is called before the first frame update
    void Start()
    {
        theText = GetComponent<Text>();

        lifeCounter = PlayerPrefs.GetInt("PlayerCurrentLives");

        character = FindObjectOfType<PlayerController>();
    }

    //Se a vida for menor que 0, inicia o ecra de game over
    //e carrega o menu principal
    void Update()
    {
        if(lifeCounter < 0)
        {
            gameOverScreen.SetActive(true);
            character.enabled = false;
        }

        if(lifeCounter > 5)
        {
            lifeCounter = 5;
        }

        theText.text = "x " + lifeCounter;

        if (gameOverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }

        if(waitAfterGameOver < 0)
        {
            Application.LoadLevel(levelToLoad);
        }
    }

    //Usado para dar e tirar vidas ao jogador
    public void GiveLife()
    {
        lifeCounter++;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }

    public void TakeLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("PlayerCurrentLives", lifeCounter);
    }
}
