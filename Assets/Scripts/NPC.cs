using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private CapsuleCollider2D bx;
    [SerializeField] private GameObject Target;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private EnemyHP hp;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        hp = GetComponent<EnemyHP>();
        bx = GetComponent<CapsuleCollider2D>();
        
    }
    void FixedUpdate()
    {

        if (transform.position.x - Target.transform.position.x < 5)
        {

            rb.velocity = new Vector3(1 * speed, rb.velocity.y);
            sr.flipX = false;

        }
        if(rb.velocity.x !=0)
        {
            anim.SetBool("Run", true);
        }
        else
            anim.SetBool("Run", false);
        if (hp.HP <= 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.bodyType = RigidbodyType2D.Static;
            bx.enabled = false;
        }

    }
}
