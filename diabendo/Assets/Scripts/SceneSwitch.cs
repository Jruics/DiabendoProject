using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneSwitch : MonoBehaviour
{

    public string levelToLoads;
    public string levelTag;

    //Muda a cena e altera os playerPrefs
    void OnTriggerEnter(Collider other){
        PlayerPrefs.SetInt(levelTag, 1);
        Application.LoadLevel(levelToLoads);
       
   }
}
