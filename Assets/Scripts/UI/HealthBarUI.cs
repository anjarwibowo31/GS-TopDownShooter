using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private bool hasParent;

    private Health health;
    private Slider slider;

    private void Start()
    {
        if (hasParent)
        {
            health = GetComponentInParent<Health>();
        }
        else
        {
            health = Player.GetPlayer.GetComponent<Health>();
        }
        slider = GetComponentInChildren<Slider>();
    }

    private void LateUpdate()
    {
        if (health == null)
        {
            slider.value = 0;
            return;
        }

        float healthValue = health.Currenthealth / health.MaxHealth;
        slider.value = healthValue;

        if (!hasParent) return;
        if (healthValue == 1)
        {
            slider.gameObject.SetActive(false);
        }
        else
        {
            slider.gameObject.SetActive(true);
        }
    }
}
