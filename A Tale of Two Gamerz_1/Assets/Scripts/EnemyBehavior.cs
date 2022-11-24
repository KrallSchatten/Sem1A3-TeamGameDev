using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public List<Transform> wayPoints;
    int nextId = 0;
    int idChangeValue = 1;

    public GameObject player;
    public Transform target;
    public float fixedRange = 20f;

    public float speed = 2;

    private void Reset()
    {

        GetComponent<BoxCollider2D>().isTrigger = true;

        GameObject root = new GameObject(name + "Root");

        root.transform.position = transform.position;

        transform.SetParent(transform);

        GameObject points = new GameObject("Waypoints");

        points.transform.SetParent(root.transform);
        points.transform.position = root.transform.position;
        //2 waypoints
        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(points.transform);
        p1.transform.position = root.transform.position;

        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(points.transform);
        p2.transform.position = root.transform.position;

        wayPoints = new List<Transform>();
        wayPoints.Add(p1.transform);
        wayPoints.Add(p2.transform);

    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;


    }

    private float Range;

    private void Update()
    {
        if (target)
        {
            Range = Vector3.Distance(transform.position, player.transform.position);
            Debug.Log("Player distance from enemy :" + Range);

            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);


            if (Range <= fixedRange)
            {

                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            }
            else
            {


                MoveToNextPoint();


            }
        }
    }

    void AttackPlayer()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;



    }

    void MoveToNextPoint()
    {
        Transform goalPoint = wayPoints[nextId];

        if (goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            if (nextId == wayPoints.Count - 1)
            {
                idChangeValue = -1;

            }
            if (nextId == 0)
            {
                idChangeValue = 1;

            }

            nextId += idChangeValue;

        }


    }
}
