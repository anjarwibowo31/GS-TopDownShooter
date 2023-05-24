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

    private void Awake()
    {
        ammo.GunAmmo = maxAmmo;
    }

    public override void PlayerCombat_OnAttackButtonClicked(object sender, PlayerCombat.OnAttackEventArgs e)
    {
        if (ammo.GunAmmo != 0)
        {
            ammo.GunAmmo--;
            GameObject obj = Instantiate(projectile, shootPoint.position, shootPoint.rotation, null);
            obj.GetComponent<Projectile>().Damage = WeaponDamage;
            //obj.GetComponent<Projectile>().StartPos = shootPoint.position;
        }
    }

    private void Update()
    {
        // Ada masalah di Execution order, makanya tak taruh sini, FIX LATER
        if (reloadTimeUIImage == null)
        {
            reloadTimeUIImage = reloadTimeUI.GetComponentInChildren<Image>();

            if (reloadTimeUIImage != null)
            {
                reloadTimeUI.SetActive(false);
            }
        }

        if (!isReloading && ammo.GunAmmo <= 0)
        {
            reloadTimeRunning = reloadTime;
            isReloading = true;
        }
        else if (isReloading)
        {
            reloadTimeUI.SetActive(true);
            reloadTimeRunning -= Time.deltaTime;
            if (reloadTimeRunning > 0)
            {
                reloadTimeUIImage.fillAmount = reloadTimeRunning / reloadTime;
            }
            else if (reloadTimeRunning <= 0)
            {
                ammo.GunAmmo = maxAmmo;
                reloadTimeUI.SetActive(false);
                isReloading = false;
            }
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
}
