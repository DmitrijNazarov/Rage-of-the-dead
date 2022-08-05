using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float offset = 0.01f;
    [SerializeField] GameObject player;
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 2*offset, player.transform.position.y + offset, transform.position.z);
    }
}
