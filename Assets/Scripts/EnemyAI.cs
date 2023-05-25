using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private LayerMask world;
    [SerializeField] private float detectRadius;
    [SerializeField] private float chasingRadius;
    [SerializeField] private float chasingSpeed;
    [SerializeField] private float roamingSpeed;

    private bool seePlayer;

    private void Update()
    {
        Vector2 playerPos = PlayerObject.GetPlayer.transform.position;
        float distance = Vector2.Distance(transform.position, playerPos);
        bool outOfSight = Physics2D.Raycast(transform.position, playerPos, distance, world);
        print(distance);
        if (distance < detectRadius && !outOfSight)
        {
            seePlayer = true;
        }
        else if (distance > chasingRadius)
        {
            seePlayer = false;
        }

        if (seePlayer && !outOfSight)
        {
            MoveTo(playerPos, chasingSpeed);
            print("Move");
        }
    }

    private void MoveTo(Vector2 direction, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, Time.deltaTime * speed);
    }
}
