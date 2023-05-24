using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : Weapon
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

    private int currentAmmo;

    private void Start()
    {
        ammo.GunAmmo = maxAmmo;
        reloadTimeUIImage = reloadTimeUI.GetComponentInChildren<Image>();
    }

    public override void PlayerCombat_OnAttackButtonClicked(object sender, PlayerCombat.OnAttackEventArgs e)
    {
        if (ammo.GunAmmo != 0 && !isReloading)
        {
            ammo.GunAmmo--;
            GameObject obj = Instantiate(projectile, shootPoint.position, shootPoint.rotation, null);
            obj.GetComponent<Projectile>().Damage = WeaponDamage;
            obj.GetComponent<Projectile>().StartPos = shootPoint.position;
        }
    }

    //private IEnumerator Reload()
    //{
    //    isReloading = true;
    //    reloadTimeUI.SetActive(true);


    //    yield return new WaitForSeconds(reloadTime);

    //    ammo.GunAmmo = maxAmmo;
    //    reloadTimeUI.SetActive(false);

    //    isReloading = false;
    //}

    private void Update()
    {
        currentAmmo = ammo.GunAmmo;
        if (!isReloading)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                isReloading = true;
                reloadTimeRunning = reloadTime;
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
            else
            {
                ammo.GunAmmo = maxAmmo;
                reloadTimeUI.SetActive(false);
                isReloading = false;
            }
        }
    }
}
