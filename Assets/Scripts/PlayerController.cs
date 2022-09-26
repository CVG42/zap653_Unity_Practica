using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    
    private float horizontal; //para el movimiento en x
    public float movespeed; //para la velocidad de movimiento
    public float suavizado;
    public Vector3 speed = Vector3.zero; //para que no se mueva en el eje z
    public bool right = true; //para detectar la direccion en la que se meuve

    public float JumpForce;
    public bool isGrounded;
    


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * movespeed; //detectar controles e identificar la direccion
        if(Input.GetKeyDown("space"))
        {
            
                playerRB.velocity = new Vector2(playerRB.velocity.x, JumpForce);
             
        }

    }

    private void FixedUpdate()
    {
        
        movement(horizontal * Time.fixedDeltaTime);
        
    }

    void movement(float move)
    {
        Vector3 ObjSpeed = new Vector2(move, playerRB.velocity.y); //velocidad a la que se desea llegar
        playerRB.velocity = Vector3.SmoothDamp(playerRB.velocity, ObjSpeed, ref speed, suavizado);
        if (move > 0 && !right)
        {
            Turn();
        }
        else if(move < 0 && right)
        {
            Turn();
        }

        

    }

    private void Turn()
    {
        right = !right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}
    

    

