using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public string LevelToLoad;

    public void Open()
    {
        Application.LoadLevel(LevelToLoad);
    }
}
