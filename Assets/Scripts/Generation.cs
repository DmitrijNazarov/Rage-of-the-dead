using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField] private GameObject StartBlock;
    [SerializeField] private GameObject End;
    [SerializeField] private GameObject Mid1;
    [SerializeField] private GameObject Mid2;
    [SerializeField] private GameObject Mid3;
    [SerializeField] private GameObject Mid4;
    [SerializeField] private GameObject R;
    [SerializeField] private GameObject L;
    private int completeLevels=0;
    private int a = Random.Range(-1, 2);
    void Start()
    {
        OnGeneratingRoutine();
    }
    private void OnGeneratingRoutine()
    {
        Vector2 position = new Vector2(0.5f, -0.17f);
        Instantiate(StartBlock, position, Quaternion.identity);
        int count = completeLevels * 2 + 100;
        position.x += 0.3f;
        for (int i = 0; i < count; i++)
        {
            if (a !=0)
                a = 0;
            else
                a = Random.Range(-1, 2);
            position.y += 0.145f * a;
            if (a == 0)
            {
                int j = Random.Range(2, 5);
                for (int k = 0; k < j; k++)
                {
                    int l = Random.Range(1, 5);
                    if (l == 1)
                    {
                        Instantiate(Mid1, position, Quaternion.identity);
                    }
                    else if (l == 2)
                    {
                        Instantiate(Mid2, position, Quaternion.identity);
                    }
                    else if (l == 3)
                    {
                        Instantiate(Mid3, position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(Mid4, position, Quaternion.identity);
                    }
                    position.x += 0.3f;

                }
            }
            else if (a==1)
            {
                Instantiate(R, position, Quaternion.identity);
                position.x += 0.3f;
            }
            else
            {
                position.y += 0.145f;
                Instantiate(L, position, Quaternion.identity);
                position.x += 0.3f;
                position.y -= 0.145f;
            }

        }
    }
}
