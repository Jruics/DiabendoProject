using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContollerPinhata : MonoBehaviour
{

    public PinhataController pinhata;

    public bool isFollowing;

    public float xOffset;
    public float yOffset;
    public float zOffset;

    // Start is called before the first frame update
    void Start()
    {
        //"Adquire" o objeto da pinhata
        pinhata = FindObjectOfType<PinhataController>();

        isFollowing = true;

    }

    // Update is called once per frame
    void Update()
    {
        //Caso esteja a camara esteja  seguir a pinhata, os movimentos da pinhata vao ser aplicados a camara
        if (isFollowing)
        {
            transform.position = new Vector3(pinhata.transform.position.x + xOffset, pinhata.transform.position.y + yOffset, pinhata.transform.position.z + zOffset);
        }

    }
}