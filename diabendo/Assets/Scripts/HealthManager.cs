using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxPlayerHealth;

    public int startingPlayerHealth;

    public static int playerHealth;

    //Text text;
    public Slider healthBar;

    private LevelManager levelManager;

    public bool isDead;

    private LifeManager lifeSystem;

    //public GameObject pauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponent<Text>();
        healthBar = GetComponent<Slider>();

        playerHealth = startingPlayerHealth;

        levelManager = FindObjectOfType<LevelManager>();

        lifeSystem = FindObjectOfType <LifeManager>();

        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Verifica se o jogador esta vivo
        if((playerHealth <= 0 && !isDead)/* || (playerHealth >= maxPlayerHealth && !isDead)*/)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            lifeSystem.TakeLife();
            isDead = true;
        }

        //Impede a vida de ultrapassar o limite
        if(playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }

        //Verifica se o jogo esta pausado
        //playerHealth -= (int) GetComponent<Rigidbody2D>().velocity.magnitude;
        if(Time.timeScale == 0f){
            return;
        }
        else
        {
            playerHealth--;
        }


        //text.text = "" + playerHealth;
        healthBar.value = playerHealth;
    }

    //Funcao para magoar o jogador
    public static void HurtPlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
    }

    //Funcao para colocar a vida no maximo
    public void FullHealth()
    {
        playerHealth = startingPlayerHealth;
    }
}
