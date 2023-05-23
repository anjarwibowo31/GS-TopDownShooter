using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    public float MaxHealth { get; private set; }
    public float Currenthealth { get; private set; }

    private void Start()
    {
        Currenthealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (Currenthealth - damage < 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Currenthealth -= damage;
        }
    }
}
