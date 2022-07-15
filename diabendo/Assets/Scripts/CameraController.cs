using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController character;

    public bool isFollowing;

    public float xOffset;
    public float yOffset;
    public float zOffset;
    // Start is called before the first frame update
    void Start()
    {
        //Encontra o jogador na cena
        character = FindObjectOfType<PlayerController>();
     

        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Aplica os movimentos do jogador a camara de forma a que o siga
        if (isFollowing)
        {
            transform.position = new Vector3(character.transform.position.x + xOffset, character.transform.position.y + yOffset, character.transform.position.z + zOffset);
        }
    }
}
