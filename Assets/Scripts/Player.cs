using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float JumpForse = 1f;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float groundRadius = 0.25f;
    [SerializeField] private LayerMask WhatIsGrounded;
    [SerializeField] private int countJump = 2;

    private int _countJump;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private bool IsAlive = false;
    int anim_count = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsAlive", false);
        sr.flipX = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _countJump > 1 && IsAlive==true)
        {
            rb.AddForce(new Vector2(0, JumpForse), ForceMode2D.Impulse);
            _countJump--;
        }
    }
    void FixedUpdate()
    {
        if (IsAlive == true)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
            if (rb.velocity.x > 0)
                sr.flipX = true;
            else if (rb.velocity.x < 0)
                sr.flipX = false;
            if (rb.velocity.x != 0)
                anim.SetBool("IsWalk", true);
            else
                anim.SetBool("IsWalk", false);
            isGrounded();
        }
        else
        { anim_count++;
            if (anim_count == 54)
            {
                IsAlive = true;
                anim.SetBool("IsAlive", true);
            }
        }
    }
    private bool isGrounded()
    {
        if (Physics2D.OverlapCircle(GroundCheck.position, groundRadius, WhatIsGrounded))
        {
            _countJump = countJump;
            anim.SetBool("IsJump", false);
            return true;
        }
        else
        {
            anim.SetBool("IsJump", true);
            return false;
        }

    }
}
