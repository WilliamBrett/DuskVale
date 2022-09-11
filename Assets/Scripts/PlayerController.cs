using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D thisRB2D;
    private Animator thisAnim;
    private SpriteRenderer thisSR;
    public Transform BottomPoint;
    public LayerMask Ground;
    public float moveSpeed;
    public float jumpForce;

    public bool DJReady;
    private bool onGround;
    
    // Start is called before the first frame update
    void Start()
    {
        thisRB2D = this.GetComponent<Rigidbody2D>();
        thisSR = this.GetComponent<SpriteRenderer>();
        thisAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        thisRB2D.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), thisRB2D.velocity.y);
        onGround = Physics2D.OverlapCircle(BottomPoint.position, 0.2f, Ground);
        if (Input.GetButtonDown("Jump"))
        {

            if (onGround)
            {
                thisRB2D.velocity = new Vector2(thisRB2D.velocity.x, jumpForce);
                DJReady = true;

            }
            else if (DJReady)
            {
                thisRB2D.velocity = new Vector2(thisRB2D.velocity.x, jumpForce);
                DJReady = false;
            }
        }

        if (thisRB2D.velocity.x > 0)
        {
            thisSR.flipX = false;
        }
        else if (thisRB2D.velocity.x < 0)
        {
            thisSR.flipX = true;
        }

        thisAnim.SetBool("onGround", onGround);
        thisAnim.SetFloat("moveSpeed", Math.Abs(thisRB2D.velocity.x));

    }
}
