using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private static int kill = 0;
    public float HP = 100;
    Animator animator;
    bool a = true;
    
    public static int getKills()
    {
        return kill;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Death", false);
    }
    private void Update()
    {
        if (HP <= 0)
        {
            animator.SetBool("Death",true);
            if (a)
            {
                HealthBar.DecreaseCurrentValue(-30f);
                a = false;
                kill += 1;

            }
        }
    }
}
