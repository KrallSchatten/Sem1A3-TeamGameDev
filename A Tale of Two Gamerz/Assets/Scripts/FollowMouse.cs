using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform Knife;
    public float radius;
    public Transform Player;
    public float Thrust = 20f;
    private Transform pivot;

    

    void Start()
    {
        pivot = Knife.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector2(transform.position.x,transform.position.y / Thrust);
        }
        else
        {
            Vector3 KnifeVector = Camera.main.WorldToScreenPoint(Knife.position);
            KnifeVector = Input.mousePosition - KnifeVector;
            float angle = Mathf.Atan2(KnifeVector.y, KnifeVector.x) * Mathf.Rad2Deg;

            pivot.position = Player.position;
            pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}
