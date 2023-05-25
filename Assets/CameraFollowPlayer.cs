using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    void Update()
    {
        Vector3 playerPos = PlayerObject.GetPlayer.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }
}
