using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerCombat;
using UnityEngine.UIElements;
using System;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform raypoint;
    [SerializeField] private LayerMask world;
    [SerializeField] private float detectRadius;
    [SerializeField] private float chasingRadius;
    [SerializeField] private float chasingSpeed;
    [SerializeField] private float roamingSpeed;
    [SerializeField] private float attackRange;

    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float reloadTime;
    [SerializeField] private float weaponDamage;
    
    private float timeToshot;
    private bool moveToPlayer;
    private float aimAngle;

    private void Update()
    {
        HandleMoving();
    }

    private void HandleMoving()
    {
        Vector2 playerPos = PlayerObject.GetPlayer.transform.position;
        float distance = Vector2.Distance(raypoint.position, playerPos);
        bool outOfSight = Physics2D.Raycast(raypoint.position, playerPos - (Vector2)raypoint.position, distance, world);
        bool? seePlayer = null;
        if (distance < detectRadius && !outOfSight)
        {
            seePlayer = true;
            if (distance < attackRange)
            {
                moveToPlayer = false;
            }
            else
            {
                moveToPlayer = true;
            }
        }
        else if (distance > chasingRadius)
        {
            moveToPlayer = false;
            seePlayer = false;
        }

        if (moveToPlayer && !outOfSight)
        {
            MoveTo(playerPos, chasingSpeed);
            print("Move");
        }

        if (outOfSight)
        {
            seePlayer = false;
            aimAngle = Mathf.Round(aimAngle / 90) * 90;
        }

        if (seePlayer == true)
        {
            HandleAiming();
            HandleFacing();
            HandleAttack();
        }
        else
        {
            aimAngle = Mathf.Round(aimAngle / 90) * 90;
        }
    }

    private void HandleAttack()
    {
        if (timeToshot > 0)
        {
            timeToshot -= Time.deltaTime;
        }
        else if (timeToshot <= 0)
        {
            timeToshot = reloadTime;
            GameObject obj = Instantiate(projectile, shootPoint.position, shootPoint.rotation, null);
            obj.GetComponent<Projectile>().Damage = weaponDamage;
        }
    }

    private void MoveTo(Vector2 direction, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, Time.deltaTime * speed);
    }

    public Vector3 GetTargetPosition()
    {
        return PlayerObject.GetPlayer.transform.position;
    }

    private void HandleAiming()
    {
        Vector3 aimDirection = (GetTargetPosition() - aimTransform.position).normalized;
        aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    }

    private void HandleFacing()
    {
        float aimLocalScale;

        if (aimAngle > 90 || aimAngle < -90)
        {
            aimLocalScale = -1f;
        }
        else
        {
            aimLocalScale = 1f;
        }

        transform.localScale = new Vector3(aimLocalScale, 1, 1);
        aimTransform.localScale = Vector3.one * aimLocalScale;
        aimTransform.localEulerAngles = new Vector3(0, 0, aimAngle * aimLocalScale);
    }

    private void OnDestroy()
    {
        LevelManager.Instance.EnemyDestroyed(this);
    }
}
