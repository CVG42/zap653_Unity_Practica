using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float JumpForce;
    public float MoveSpeed;
    public float horizontalInput;
    public bool isGrounded;
    public LayerMask ground;

    private Rigidbody2D RB;
    private Collider2D Collider;
    private Animator Playeranimation;


    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        Playeranimation = GetComponent<Animator>();
    }


    void Update()
    {
        isGrounded = Physics2D.IsTouchingLayers(Collider, ground);

        RB.velocity = new Vector2(MoveSpeed, RB.velocity.y); //no se necesita Timme.deltaTime porque ya viene con el velocity (también para AddForce)
        
        //RB.AddForce(new Vector2(horizontalInput * MoveSpeed, transform.position.y), ForceMode2D.Force); ForceMode2D es para el tipo de fuerza, ya sea .Force o .Impulse
        //.Force añade sólo 1 fuerza es continuo, mientras que el .Impulse es más drástico
        //velocity y transform usarlas para movimiento y AddForce para el salto.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                RB.velocity = new Vector3(RB.velocity.x, JumpForce);
            }
        }

        Playeranimation.SetBool("Grounded", isGrounded);
    }


}
