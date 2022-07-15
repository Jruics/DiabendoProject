using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string startLevel;

    public string homeScreen;

    public string instructions;

    public string controls;

    public string levelSelect;

    public int playerLives;

    public string level1Tag;

    //Inicia um novo jogo com as definicoes corretas
    public void NewGame()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);

        PlayerPrefs.SetInt("CurrentScore", 0);

        PlayerPrefs.SetInt(level1Tag, 1);

        PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);

        Application.LoadLevel(startLevel);
    }

    //Inicia a escolha de nivel
    public void LevelSelect()
    {
        PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);

        PlayerPrefs.SetInt("CurrentScore", 0);

        PlayerPrefs.SetInt(level1Tag, 1);

        if (!PlayerPrefs.HasKey("PlayerLevelSelectPosition"))
        {
            PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
        }

        Application.LoadLevel(levelSelect);
    }

    //Carrega os niveis corretos
    public void Instructions()
    {
        Application.LoadLevel(instructions);
    }

    public void Controls()
    {
        Application.LoadLevel(controls);
    }

    public void HomeScreen()
    {
        Application.LoadLevel(homeScreen);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
