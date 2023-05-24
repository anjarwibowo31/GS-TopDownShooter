using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float experiencePointsGiven;

    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public float Currenthealth { get; private set; }


    private void Start()
    {
        Currenthealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (Currenthealth - damage <= 0)
        {
            Destroy(this.gameObject);
            ProgressDataKeeper.Instance.AwardExperience(experiencePointsGiven);
        }
        else
        {
            Currenthealth -= damage;
            print($"{gameObject.name}: {Currenthealth}");
        }
    }
}
