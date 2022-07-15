using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinhataHealthSystem : MonoBehaviour
{
    public int maxBossHealth;

    public int startingBossHealth;

    public static int bossHealth;

    //Text text;
    public Slider bossHealthBar;

    private LevelManager levelManager;

    public Pinhata boss;

    public bool isDead;

    //private LifeManager lifeSystem;

    //public GameObject pauseMenuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponent<Text>();
        bossHealthBar = GetComponent<Slider>();

        bossHealth = startingBossHealth;

        levelManager = FindObjectOfType<LevelManager>();

        boss = FindObjectOfType<Pinhata>();

        isDead = false;
    }

    //Gere a vida do boss
    void Update()
    {
        if ((boss.health <= 0 && !isDead))
        {
            boss.health = 0;
            isDead = true;
        }

        bossHealthBar.value = boss.health;
    }

    public static void HurtBoss(int damageToGive)
    {
        bossHealth -= damageToGive;
    }

    public void FullHealth()
    {
        bossHealth = startingBossHealth;
    }
}
