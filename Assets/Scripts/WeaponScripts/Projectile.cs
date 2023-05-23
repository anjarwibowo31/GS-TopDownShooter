using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage { get; set; }
    public Vector3 StartPos { get; set; }

    [SerializeField] private float lifetime = 2f;

    [SerializeField] private float speed = 100;
    [SerializeField] private GameObject particleEffect;

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<IDamagable>()?.TakeDamage(Damage);
        Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
