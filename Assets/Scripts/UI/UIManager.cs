using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;

    private void Awake()
    {
        ToMainMenu();
    }

    public void ToMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        credits.SetActive(false);
    }

    public void OnCreditsClicked()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        credits.SetActive(true);
    }

    public void OnOptionsClicked()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        credits.SetActive(false);
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
