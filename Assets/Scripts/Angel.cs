using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    private Transform tr;
    private Player hero;
    public int damage = 20;
    private float checkTime = 0;
    CircleCollider2D cc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hero = GetComponent<Player>();
        cc = GetComponent<CircleCollider2D>();
    }
    void FixedUpdate()
    {
        checkTime += 1;
        if (checkTime > 300)
        {

            cc.enabled = false;
        }
        else if (checkTime > 600)
        {
            cc.enabled = true;
            checkTime = 0;
        }
    }
}