using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generation : MonoBehaviour
{
    [SerializeField] private GameObject StartBlock;
    [SerializeField] private GameObject End;
    [SerializeField] private GameObject NPC1;
    [SerializeField] private GameObject Mid1;
    [SerializeField] private GameObject Mid2;
    [SerializeField] private GameObject Mid3;
    [SerializeField] private GameObject Mid4;
    [SerializeField] private GameObject Upside;
    [SerializeField] private GameObject R;
    [SerializeField] private GameObject L;
    [SerializeField] private GameObject H1;
    [SerializeField] private GameObject H1U;
    [SerializeField] private GameObject Player;

    private int completeLevels=0;
    private int a ;
    Vector2 pos;
    void Start()
    {
        a = Random.Range(-1, 2);
        OnGeneratingRoutine();
    }
    private void OnGeneratingRoutine()
    {
        Vector2 position = new Vector2(0.5f, -0.17f);
        Instantiate(StartBlock, position, Quaternion.identity);
        position.y -= 2.5f;
        Instantiate(Upside, position, Quaternion.identity);
        position.y += 2.5f;
        int count = completeLevels * 2 + 100;
        position.x += 0.3f;
        for (int i = 0; i < count; i++)
        {
            if (a !=0 )
                a = 0;
            else
                a = Random.Range(-1, 2);
            position.y += 0.145f * a;
            if (a == 0)
            {
                int j = Random.Range(2, 10);
                if (j < 8)
                    for (int k = 0; k < j; k++)
                    {
                        int l = Random.Range(1, 5);
                        if (l == 1)
                        {
                            Instantiate(Mid1, position, Quaternion.identity);
                            position.y -= 2.5f;
                            Instantiate(Upside, position, Quaternion.identity);
                            position.y += 2.75f;
                            int g = Random.Range(1,10);
                            if (g == 5)
                            {
                                Instantiate(NPC1, position, Quaternion.identity);
                            }
                            position.y -= 0.25f;
                        }
                        else if (l == 2)
                        {
                            Instantiate(Mid2, position, Quaternion.identity);
                            position.y -= 2.5f;
                            Instantiate(Upside, position, Quaternion.identity);
                            position.y += 2.75f;
                            int g = Random.Range(1, 10);
                            if (g == 5)
                            {
                                Instantiate(NPC1, position, Quaternion.identity);
                            }
                            position.y -= 0.25f;
                        }
                        else if (l == 3)
                        {
                            Instantiate(Mid3, position, Quaternion.identity);
                            position.y -= 2.5f;
                            Instantiate(Upside, position, Quaternion.identity);
                            position.y += 2.75f;
                            int g = Random.Range(1, 10);
                            if (g == 5)
                            {
                                Instantiate(NPC1, position, Quaternion.identity);
                            }
                            position.y -= 0.25f;
                        }
                        else
                        {
                            Instantiate(Mid4, position, Quaternion.identity);
                            position.y -= 2.5f;
                            Instantiate(Upside, position, Quaternion.identity);
                            position.y += 2.75f;
                            int g = Random.Range(1, 10);
                            if (g == 5)
                            {
                                Instantiate(NPC1, position, Quaternion.identity);
                            }
                            position.y -= 0.25f;
                        }
                        position.x += 0.3f;
                    }
                else if (j==9)
                {
                    position.x += 1.424f;
                    position.y += 0.53f;
                    Instantiate(H1, position, Quaternion.identity);
                    position.x -= 0.125f;
                    position.y -= 4.498f;
                    Instantiate(H1U, position, Quaternion.identity);
                    position.x += 0.125f;
                    position.y += 4.498f;
                    position.y -= 0.53f;
                    position.x += 1.476f;
                    a = 0;


                }
            }
            else if (a==1)
            {
                Instantiate(R, position, Quaternion.identity);
                position.y -= 2.5f;
                Instantiate(Upside, position, Quaternion.identity);
                position.y += 2.5f;
                position.x += 0.3f;

            }
            else
            {
                position.y += 0.145f;
                Instantiate(L, position, Quaternion.identity);
                position.y -= 2.5f;
                Instantiate(Upside, position, Quaternion.identity);
                position.y += 2.5f;
                position.x += 0.3f;
                position.y -= 0.145f;
            }
        }
        position.x += 1.37f;
        position.y += 0.97f;
        Instantiate(End, position, Quaternion.identity);
        position.x -= 0.07f;
        position.y -= 4.9f;
        Instantiate(H1U, position, Quaternion.identity);
        position.x += 0.07f;
        position.y += 4.9f;
        pos = position;

    }
    private void FixedUpdate()
    {
        if (Player.transform.position.x - pos.x >0.5 && Player.transform.position.x - pos.x < 1.3)
        {
            SceneManager.LoadScene("Background Example 2");
        }
    }
}
