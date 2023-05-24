using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealingObstacles : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float damage;
    [SerializeField] private LayerMask playerLayer;

    private void Update()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if (player != null)
        {
            player.gameObject.GetComponent<IDamagable>()?.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
