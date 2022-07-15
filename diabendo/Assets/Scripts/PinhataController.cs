using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinhataController : MonoBehaviour
{
    //velocidade da pinhata
    public float movePinhataSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movimenta a pinhata
        GetComponent<Rigidbody2D>().velocity = new Vector2(movePinhataSpeed, GetComponent<Rigidbody2D>().velocity.x);


    }
}
