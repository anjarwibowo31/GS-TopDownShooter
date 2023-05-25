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
    [SerializeField] private float attackRange;
    private bool moveToPlayer;

    private void Update()
    {
        Vector2 playerPos = PlayerObject.GetPlayer.transform.position;
        float distance = Vector2.Distance(transform.position, playerPos);
        bool outOfSight = Physics2D.Raycast(transform.position, playerPos - (Vector2)transform.position, distance, world);

        if (distance < detectRadius && !outOfSight)
        {
            if (distance < attackRange)
            {
                moveToPlayer = false;
                return;
            }
            moveToPlayer = true;
        }
        else if (distance > chasingRadius)
        {
            moveToPlayer = false;
        }

        if (moveToPlayer && !outOfSight)
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
