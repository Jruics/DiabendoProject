using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool atEdge;
    public Transform edgeCheck;

    public Transform enemyCheck;
    public float enemyCheckRadius;
    public LayerMask whatIsEnemy;
    private  bool foundEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Verifica se o inimigo esta a tocar em paredes, prestes a cair ou a tocar em outros inimigos
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        foundEnemy = Physics2D.OverlapCircle(enemyCheck.position, enemyCheckRadius, whatIsEnemy);

        //Caso esteja a tocar, patrulha na outra direcao
        if (hittingWall || !atEdge || foundEnemy)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
            GetComponent<Rigidbody2D>().velocity  = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
