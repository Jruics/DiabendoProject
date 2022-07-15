using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnime : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Determina os inputs do jogador de forma a introduzir a animacao correta
        if(/*Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)*/GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            anim.SetBool("isRunning", true);
        }else if(GetComponent<Rigidbody2D>().velocity.x < 0)
        {
             anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if(Input.GetKey(KeyCode.W)){
            anim.SetTrigger("jump");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("atack");
        }


        /*
         * if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(0.1865696f, 0.1865696f, 0.1865696f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-0.1865696f, 0.1865696f, 0.1865696f);
        */
        RunningAnim();
    }

    //Lida com a animacao de correr
    public void RunningAnim()
    {
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(0.1865696f, 0.1865696f, 0.1865696f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-0.1865696f, 0.1865696f, 0.1865696f);
    }
}
