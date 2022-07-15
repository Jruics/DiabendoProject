using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectTouch : MonoBehaviour
{
    public LevelSelectManager theLevelSelectManager;

    //public int positionSelector;


    // Start is called before the first frame update
    void Start()
    {
        theLevelSelectManager = FindObjectOfType<LevelSelectManager>();

        theLevelSelectManager.touchMode = true;

        //positionSelector = PlayerPrefs.GetInt("PlayerLevelSelectPosition");
    }

    //Move o icone do jogador para e esquerada e direita
    public void MoveLeft()
    {
        theLevelSelectManager.positionSelector -= 1;

        if (theLevelSelectManager.positionSelector < 0)
        {
            theLevelSelectManager.positionSelector = 0;
        }
    }

    public void MoveRight()
    {
        theLevelSelectManager.positionSelector += 1;

        if (theLevelSelectManager.positionSelector >= theLevelSelectManager.levelTags.Length)
        {
            theLevelSelectManager.positionSelector = theLevelSelectManager.levelTags.Length - 1;
        }
    }

    //Carrega o nivel
    public void LoadLevel()
    {
        PlayerPrefs.SetInt("PlayerLevelSelectPosition", theLevelSelectManager.positionSelector);
        Application.LoadLevel(theLevelSelectManager.levelName[theLevelSelectManager.positionSelector]);
    }
}
