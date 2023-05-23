using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerDataSO : ScriptableObject
{
    public enum State
    {
        Play,
        Dead,
        Victory
    }

    public State PlayState { get; set; }

    public enum WeaponType
    {
        Melee = 0,
        Gun = 1,
        Grenade = 2
    }

    public WeaponType weapon { get; set; }
}
