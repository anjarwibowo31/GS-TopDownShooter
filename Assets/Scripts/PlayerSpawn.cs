using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Ada masalah di (mungkin) Script Execution Order yang belum bisa saya solve, jadi ini penyelesaian masalahnya
    private void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
