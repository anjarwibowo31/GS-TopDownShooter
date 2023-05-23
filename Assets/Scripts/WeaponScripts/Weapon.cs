using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private float weaponDamage;

    public float WeaponDamage
    {
        get { return weaponDamage; }
        set { WeaponDamage = value; }
    }

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
