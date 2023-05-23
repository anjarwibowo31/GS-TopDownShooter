using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProgressDataKeeper : MonoBehaviour
{
    public static ProgressDataKeeper Instance { get; private set; }

    public float Coin { get; set; }
    public float Experience { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AwardExperience(float exp)
    {
        Experience += exp;
    }

    private void Update()
    {
        print(Instance.Experience);
    }
}
