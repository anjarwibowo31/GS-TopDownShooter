using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPoint;

    public override void PlayerCombat_OnAttackButtonClicked(object sender, PlayerCombat.OnAttackEventArgs e)
    {
        GameObject obj = Instantiate(projectile, shootPoint.position, shootPoint.rotation, null);
        obj.GetComponent<Projectile>().Damage = WeaponDamage;
        obj.GetComponent<Projectile>().StartPos = shootPoint.position;
    }
}
