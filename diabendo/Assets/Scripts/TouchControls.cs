using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    private PlayerController thePlayer;
    private PlayerAttack thePlayerAttacks;

    public float timeBtwAttack;
    public float startTimeBtwAttack;

    public float moveSpeed;

    public Transform attackPos;
    public LayerMask whatIsPinhata;
    public float attackRange;
    public int damage;

    private LevelLoader levelExit;

    private PauseMenu thePauseMenu;

    //Encontra os objetos na cena
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        levelExit = FindObjectOfType<LevelLoader>();
        thePauseMenu = FindObjectOfType<PauseMenu>();
        //thePlayerAttacks = FindObjectOfType<PlayerController>();

    }

    

    //Ao carregar nas setas move o jogador
    public void LeftArrow()
    {
        //thePlayer.Move(-1 * thePlayer.getMoveSpeed());
        //Debug.Log("Before leftArrow MoveSpeed: " + moveSpeed);
        thePlayer.Move(-1);
        //Debug.Log("Afer leftArrow MoveSpeed: " + moveSpeed);
        //Debug.Log("Left Arrow Pressed");
    }

    public void RightArrow()
    {
        //thePlayer.Move(1 * thePlayer.getMoveSpeed());
        //Debug.Log("Before rightArrow MoveSpeed: " + moveSpeed);
        thePlayer.Move(1);
        //Debug.Log("After rightArrow MoveSpeed: " + moveSpeed);
        //Debug.Log("Right Arrow Pressed");
    }

    public void UnpressedArrow()
    {
        //Debug.Log("Arrow Unpressed");
        thePlayer.Move(0);
        //Debug.Log("Key Unpressed MoveSpeed: " + moveSpeed);
    }

    //Ao carregar no ataque, ataca corretamento
    public void Attack()
    {
        Collider2D[] pinhataToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsPinhata);
        for (int i = 0; i < pinhataToDamage.Length; i++)
        {
            Debug.Log("Pinhata:" + pinhataToDamage[i]);
            Debug.Log("Pinhata Component:" + pinhataToDamage[i].GetComponent<Pinhata>());
            pinhataToDamage[i].GetComponent<Pinhata>().TakeDamage(damage);
            //Attack(pinhataToDamage, i);

        }
    }

    //Salto para touch controls
    public void Jump()
    {
        if (levelExit.playerInZone)
        {
            levelExit.LoadLevel();
        }
        Debug.Log("Jump Pressed");
        thePlayer.Jump();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    public void Pause()
    {
        thePauseMenu.PauseUnpause();

        //thePauseMenu.isPaused = !thePauseMenu.isPaused;
    }
}
