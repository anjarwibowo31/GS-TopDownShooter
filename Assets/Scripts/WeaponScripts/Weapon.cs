using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float weaponDamage { get; set; }

    public bool isRequireHand { get; set; }

    private void OnEnable()
    {
        PlayerCombat.OnAttackButtonClicked += PlayerCombat_OnAttackButtonClicked;
    }

    private void OnDisable()
    {
        PlayerCombat.OnAttackButtonClicked -= PlayerCombat_OnAttackButtonClicked;
    }

    public virtual void PlayerCombat_OnAttackButtonClicked(object sender, PlayerCombat.OnAttackEventArgs e)
    {
        Debug.LogError("No Override");
    }
}
