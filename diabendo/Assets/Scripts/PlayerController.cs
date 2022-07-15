using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

// ---------------------------------------------------------------------------- Variaveis  --------------------------------------------------------------------------------- //
    public float moveSpeed;
    public float jumpHeight;
    private bool doubleJumped;
    public float moveVelocity;

    //-- Todas as variaveis que se encontram abaixo são necessarias para certeficarmos que o nosso heroi toca no solo
       // -- Transform é um ponto num espaço, basicamente é um objeto que têm localização e rotação
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private bool grounded;

    public AudioSource jumpSoundEffect;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    //private Animator anim;

    // ---------------------------------------------------------------------------- Functions--------------------------------------------------------------------------------- //

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Função que permite fazer algo, um numero determinado de vezes por segundo
    void FixedUpdate() { 
        // Vai criar um pequeno circulo 
       grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround );
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded){

            doubleJumped = false ;

        }

#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if(Input.GetKeyDown (KeyCode.W) && grounded ) 
        {
            jumpSoundEffect.Play();
            Jump();
        }
        

        if(Input.GetKeyDown (KeyCode.W) && !grounded && !doubleJumped) 
        {
            jumpSoundEffect.Play();
            Jump();

            doubleJumped = true ;
        }


        //moveVelocity = 0f;
        Move(Input.GetAxisRaw("Horizontal"));
#endif

        if (Input.GetKey(KeyCode.D))
        {
            //moveVelocity = moveSpeed;
            Move(1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //moveVelocity = -moveSpeed;
            Move(-1);
        }


        if(knockbackCount <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            if (knockFromRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);
            }
            if (!knockFromRight)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
            }
            knockbackCount -= Time.deltaTime;
        }
        



        /*if(Input.GetKey (KeyCode.D)) 
        {
            anim.SetBool("isRunning", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }else if(Input.GetKey (KeyCode.A)) 
        {
            anim.SetBool("isRunning", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }*/



        /*if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(0.1865696f, 0.1865696f, 0.1865696f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-0.1865696f, 0.1865696f, 0.1865696f);*/
    }

    public void Move(float moveInput)
    {
        //Debug.Log("Move() has been called with moveInput:" + moveInput + "and moveSpeed:" + moveSpeed);
        moveVelocity = moveSpeed * moveInput;
        Debug.Log("Move Velocity: " + moveVelocity);
    }



    public float getMoveSpeed()
    {
        return moveSpeed;
    }

    public void Jump()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

        if (grounded)
        {
            jumpSoundEffect.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

        }


        if (!grounded && !doubleJumped)
        {
            jumpSoundEffect.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);


            doubleJumped = true;
        }
    }
}
