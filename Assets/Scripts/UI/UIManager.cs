using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject levelSelection;

    [SerializeField] private TextMeshProUGUI experience;

    private void Start()
    {
        ToMainMenu();
        experience.text = ProgressDataKeeper.Instance.Experience.ToString();
    }

    public void OnPlayClicked()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        credits.SetActive(false);
        levelSelection.SetActive(true);
    }

    public void ToMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        credits.SetActive(false);
        levelSelection.SetActive(false);
    }

    public void OnCreditsClicked()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        credits.SetActive(true);
        levelSelection.SetActive(false);
    }

    public void OnOptionsClicked()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        credits.SetActive(false);
        levelSelection.SetActive(false);
    }

    public void OnLevelClicked(int level)
    {
        SceneManager.LoadScene("Level" + level.ToString());
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
