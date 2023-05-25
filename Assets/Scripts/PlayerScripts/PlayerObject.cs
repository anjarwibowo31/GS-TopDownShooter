using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObject : MonoBehaviour
{
    public static GameObject GetPlayer { get; set; }

    private void Awake()
    {
        GetPlayer = this.gameObject;
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
