using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Transform Knife;
    public float radius;
    public Transform Player;
    public bool Attacking;
    private Transform pivot;
    public Animator animator;

    void Start()
    {
        //Vector3 local = transform.localScale;

        pivot = Knife.transform;
        transform.parent = pivot;
        //transform.position += Vector3.up * radius;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attacking", true);
            Attacking = true;
            //transform.localScale = new Vector3(20, 20, 0);
        }
        else
        {
            Vector3 KnifeVector = Camera.main.WorldToScreenPoint(Knife.position);
            KnifeVector = Input.mousePosition - KnifeVector;
            float angle = Mathf.Atan2(KnifeVector.y, KnifeVector.x) * Mathf.Rad2Deg;

            animator.SetBool("Attacking", false);
            Attacking = false;
            //transform.localScale = new Vector3(1, 1, 0);

            pivot.position = Player.position;
            pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}
