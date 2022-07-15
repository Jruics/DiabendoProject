using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;

    private PlayerController character;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public float respawnDelay;

    public Transform head;
    public Transform body;
    public Transform leftHand;
    public Transform rightHand;
    public Transform leftShoe;
    public Transform rightShoe;


    public HealthManager healthManager;

    private float gravityStore;

    private CameraController camera;

    public int pointPenaltyOnDeath;
    // Start is called before the first frame update
    void Start()
    {
        character = FindObjectOfType<PlayerController>();

        healthManager = FindObjectOfType<HealthManager>();

        camera = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Função que vai ser chamada para posteriormente 
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    //Funcao para dar respawn ao jogador
    public IEnumerator RespawnPlayerCo()
    {
        head = character.transform.Find("Body/Head");
        body = character.transform.Find("Body");
        leftHand = character.transform.Find("Body/Left Hand");
        rightHand = character.transform.Find("Body/Right Hand");
        leftShoe = character.transform.Find("Shoe 1");
        rightShoe = character.transform.Find("Shoe 2");

        Instantiate(deathParticle, character.transform.position, character.transform.rotation);
        character.enabled = false;
        head.GetComponent<Renderer>().enabled = false;
        body.GetComponent<Renderer>().enabled = false;
        leftHand.GetComponent<Renderer>().enabled = false;
        rightHand.GetComponent<Renderer>().enabled = false;
        leftShoe.GetComponent<Renderer>().enabled = false;
        rightShoe.GetComponent<Renderer>().enabled = false;
        camera.isFollowing = false;
        // vai apresentar no canto inferior esquerdo do unity o que estiver dentro de ""
        ScoreManager.AddPoints(-300);
        Debug.Log("Player Respawn");
        yield return new WaitForSeconds(respawnDelay);
        camera.isFollowing = true;
        character.transform.position = currentCheckpoint.transform.position;
        character.enabled = true;
        head.GetComponent<Renderer>().enabled = true;
        body.GetComponent<Renderer>().enabled = true;
        leftHand.GetComponent<Renderer>().enabled = true;
        rightHand.GetComponent<Renderer>().enabled = true;
        leftShoe.GetComponent<Renderer>().enabled = true;
        rightShoe.GetComponent<Renderer>().enabled = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

        healthManager.FullHealth();
        healthManager.isDead = false;
    }
}
