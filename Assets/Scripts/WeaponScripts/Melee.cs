using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Weapon
{
    [SerializeField] private Animator animator;

    private const string MELEE_IDLE = "Melee_Idle";
    private const string MELEE_ATTACK = "Melee_Attack";

    public override void PlayerCombat_OnAttackButtonClicked(object sender, PlayerCombat.OnAttackEventArgs e)
    {
        animator.Play(MELEE_ATTACK);
    }

    // Called by Animation Event
    public void ReturnIdle()
    {
        animator.Play(MELEE_IDLE);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<IDamagable>()?.TakeDamage(WeaponDamage);
    }
}
