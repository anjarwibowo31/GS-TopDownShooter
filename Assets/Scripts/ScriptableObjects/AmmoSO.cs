using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AmmoSO : ScriptableObject
{
    public int GunAmmo { get; set; }

    [SerializeField] GameObject gunAmmoObject;
    public GameObject GunAmmoObject
    {
        get
        {
            return gunAmmoObject;
        }
        set
        {
            gunAmmoObject = value;
        }
    }

    public int GrenadeAmmo { get; set;}

    [SerializeField] GameObject grenadeAmmoObject;
    public GameObject GrenadeAmmoObject
    {
        get
        {
            return grenadeAmmoObject;
        }
        set
        {
            grenadeAmmoObject = value;
        }
    }
}
