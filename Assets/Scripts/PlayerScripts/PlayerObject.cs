using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public static GameObject GetPlayer { get; set; }

    private void Awake()
    {
        GetPlayer = this.gameObject;
    }
}
