using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public GameObject objectCollider;
    public GameObject anotherCollider;

    void Start()
    {
        Health = 5;



        objectCollider = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider2D>();
        anotherCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame

      void Update()
      {
        if (objectCollider.IsTouching(anotherCollider))
        {
            Health -= 1;
        }
       
      }
}
