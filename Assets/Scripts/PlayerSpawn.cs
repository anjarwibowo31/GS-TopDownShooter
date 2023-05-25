using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Ada masalah di (mungkin) Script Execution Order yang belum bisa saya solve, jadi ini penyelesaian masalahnya
        // Update: sudah ketemu masalahnya di Event subscriber, tapi untuk sementara pakai system ini dulu
    private void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
