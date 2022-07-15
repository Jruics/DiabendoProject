using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlOpen : MonoBehaviour
{
    public string Url;

    public void Open()
    {
        //Abre URL ao interagir
        Application.OpenURL(Url);
    }
}
