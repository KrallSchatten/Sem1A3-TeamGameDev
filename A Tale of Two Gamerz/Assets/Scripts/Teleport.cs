using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    float distance = 500;
    public GameObject Trapdoor;
    void OnTriggerEnter2D(Collider2D Trapdoor)
    {
        transform.position = new Vector2(transform.position.x + distance, transform.position.y);
    }
}
