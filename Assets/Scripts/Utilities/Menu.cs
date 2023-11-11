using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu, optionsMenu;
    [SerializeField] private Slider gameSessionSlider, enemySpawnSlider;
    [SerializeField] private TextMeshProUGUI enemySpawnValueText;
    [SerializeField] private TextMeshProUGUI gameTimeValueText;

    private void Update()
    {
        if (optionsMenu.activeSelf)
        {
            enemySpawnValueText.text = Math.Round(enemySpawnSlider.value, 1).ToString();
            gameTimeValueText.text = Math.Round(gameSessionSlider.value, 1).ToString();
        }
    }

    public void Play()
    {
        if (!PlayerPrefs.HasKey("GameSessionTime") || !PlayerPrefs.HasKey("EnemySpawnTime"))
        {
            PlayerPrefs.SetInt("GameSessionTime", (int)gameSessionSlider.value);
            PlayerPrefs.SetFloat("EnemySpawnTime", (float)Math.Round(enemySpawnSlider.value, 1));
            PlayerPrefs.Save();

        }

        SceneManager.LoadScene("Game");
    }

    public void Options()
    {
        menu.SetActive(false);
        optionsMenu.SetActive(true);   
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Return()
    {
        PlayerPrefs.SetInt("GameSessionTime", (int)gameSessionSlider.value);
        PlayerPrefs.SetFloat("EnemySpawnTime", (float)Math.Round(enemySpawnSlider.value, 1));
        PlayerPrefs.Save();

        optionsMenu.SetActive(false);
        menu.SetActive(true);
    }
}
