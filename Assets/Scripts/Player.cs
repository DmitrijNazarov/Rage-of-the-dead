using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float JumpForse = 1f;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float groundRadius = 0.1f;
    [SerializeField] private LayerMask WhatIsGrounded;
    [SerializeField] private int countJump = 2;
    private bool z = false;
    private bool x = false;
    private int anim_count = 0;
    private int _countJump;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    [SerializeField] private Transform punch1;
    [SerializeField] private float punch1Radius;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack2D.Action(punch1.position, punch1Radius, 8, 12, true);
            anim.SetTrigger("Atack1");
            z = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack2D.Action(punch1.position, punch1Radius, 8, 12, false);
            anim.SetTrigger("Atack2");
            x = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && _countJump > 1)
            {
                rb.AddForce(new Vector2(0, JumpForse), ForceMode2D.Impulse);
                _countJump--;
            }
    }
        void FixedUpdate()
        {

            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
            if (rb.velocity.x > 0)
                sr.flipX = false;
            else if (rb.velocity.x < 0)
                sr.flipX = true;
            if (rb.velocity.x != 0)
                anim.SetBool("IsWalk", true);
            else
                anim.SetBool("IsWalk", false);
            isGrounded();
            if (z)
        {
            speed = 0;
            anim_count++;
        }
        if (anim_count == 36)
        {
            z = false;
            anim_count = 0;
            speed = 1.5f;
        }
        if (x)
            {speed = 0;
            anim_count++;
        }
        if (anim_count == 51)
        {
            x = false;
            anim_count = 0;
            speed = 1.5f;
        }

    }
         private bool isGrounded()
        {
            if (Physics2D.OverlapCircle(GroundCheck.position, groundRadius, WhatIsGrounded))
            {
                _countJump = countJump;
                anim.SetBool("IsFall", false);
                return true;
            }
            else
            {
                anim.SetBool("IsFall", true);
                return false;
            }

        }
    
}
