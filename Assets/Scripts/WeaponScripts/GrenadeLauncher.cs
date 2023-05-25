using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeLauncher : Weapon
{
    [SerializeField] private AmmoSO ammo;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootPoint;

    [SerializeField] private int maxAmmo;
    [SerializeField] private float reloadTime;
    [SerializeField] private GameObject reloadTimeUI;

    private Image reloadTimeUIImage;
    private float reloadTimeRunning;
    private bool isReloading = false;

    private void Awake()
    {
        ammo.GrenadeAmmo = maxAmmo;
    }

    public override void PlayerCombat_OnAttackButtonClicked(object sender, PlayerCombat.OnAttackEventArgs e)
    {
        if (ammo.GrenadeAmmo != 0 && !isReloading)
        {
            ammo.GrenadeAmmo--;
            GameObject obj = Instantiate(projectile, shootPoint.position, Quaternion.identity, null);
            obj.GetComponent<Grenade>().Damage = WeaponDamage;
            isReloading = true;
            reloadTimeRunning = reloadTime;
        }
    }

    private void Update()
    {
        if (reloadTimeUIImage == null)
        {
            reloadTimeUIImage = reloadTimeUI.GetComponentInChildren<Image>();

            if (reloadTimeUIImage != null)
            {
                reloadTimeUI.SetActive(false);
            }
        }

        if (isReloading)
        {
            reloadTimeUI.SetActive(true);
            reloadTimeRunning -= Time.deltaTime;
            if (reloadTimeRunning > 0)
            {
                reloadTimeUIImage.fillAmount = reloadTimeRunning / reloadTime;
            }
            else if (reloadTimeRunning <= 0)
            {
                reloadTimeUI.SetActive(false);
                isReloading = false;
            }
        }
    }
}
