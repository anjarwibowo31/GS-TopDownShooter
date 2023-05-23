using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage { get; set; }
    public Vector3 StartPos { get; set; }

    [SerializeField] private float lifetime = 5f;

    [SerializeField] private float speed = 100;

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        Destroy(gameObject, lifetime);
    }
}
