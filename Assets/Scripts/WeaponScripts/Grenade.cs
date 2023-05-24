using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float Damage { get; set; }

    [SerializeField] private float countdown = 3f;

    [SerializeField] private float force = 20;
    [SerializeField] private float forceTime = 0.5f;
    [SerializeField] private ParticleSystem sparklingEffect;
    [SerializeField] private ParticleSystem explosionEffect;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * force;
    }

    private void Update()
    {
        forceTime -= Time.deltaTime;
        if (forceTime < 0)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            StartCountdown();
        }
        print(countdown);
    }

    private void StartCountdown()
    {
        sparklingEffect.Play();
        countdown -= Time.deltaTime;
        if (countdown < 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        if (!explosionEffect.isPlaying)
        {
            explosionEffect.Play();
        }

        Destroy(gameObject, 0.2f);
    }
}