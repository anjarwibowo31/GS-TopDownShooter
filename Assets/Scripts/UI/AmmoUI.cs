using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private AmmoSO ammoSO;
    [SerializeField] private bool isGunUI;

    private bool isGrenadeUI;
    private int currentAmmo;

    private void Awake()
    {
        isGrenadeUI = !isGunUI;

        if (isGunUI)
        {
            if (currentAmmo != ammoSO.GunAmmo)
            {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }

                for (int i = 0; i < ammoSO.GunAmmo; i++)
                {
                    Instantiate(ammoSO.GunAmmoObject, transform);
                }
            }

            currentAmmo = ammoSO.GunAmmo;
        }

        if (isGrenadeUI)
        {
            if (currentAmmo != ammoSO.GrenadeAmmo)
            {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }

                for (int i = 0; i < ammoSO.GrenadeAmmo; i++)
                {
                    Instantiate(ammoSO.GrenadeAmmoObject, transform);
                }
            }
            currentAmmo = ammoSO.GrenadeAmmo;
        }
    }

    private void Update()
    {
        if (isGunUI)
        {
            if (currentAmmo != ammoSO.GunAmmo)
            {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }

                for (int i = 0; i < ammoSO.GunAmmo; i++)
                {
                    Instantiate(ammoSO.GunAmmoObject, transform);
                }
            }

            currentAmmo = ammoSO.GunAmmo;
        }

        if (isGrenadeUI)
        {
            if (currentAmmo != ammoSO.GrenadeAmmo)
            {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }

                for (int i = 0; i < ammoSO.GrenadeAmmo; i++)
                {
                    Instantiate(ammoSO.GrenadeAmmoObject, transform);
                }
            }
            currentAmmo = ammoSO.GrenadeAmmo;
        }
    }
}
