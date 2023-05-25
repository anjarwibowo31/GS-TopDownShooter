using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressDataKeeper : MonoBehaviour
{
    public static ProgressDataKeeper Instance { get; private set; }

    private float coin = 0;
    public float Coin
    {
        get { return coin; }
        set { coin = value; }
    }

    private float experience = 0;
    public float Experience
    {
        get { return experience; }
        set { experience = value; }
    }

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
        print("Experience Points " + Instance.Experience);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
