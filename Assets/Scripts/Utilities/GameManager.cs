using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int points;

    //UI
    [SerializeField] private GameObject pauseMenu, gameOverScreen;
    [SerializeField] private TextMeshProUGUI currentPoints, totalPoints, timeLeft;

    private void OnEnable()
    {
        PlayerController.OnPlayerPauseGame += OpenPauseGameMenu;
        Player.OnGameOver += OpenGameOverScreen;
        Enemy.OnEnemyShipDestroyed += AddPoints;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerPauseGame -= OpenPauseGameMenu;
        Player.OnGameOver -= OpenGameOverScreen;
        Enemy.OnEnemyShipDestroyed -= AddPoints;
    }

    public void OpenPauseGameMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void OpenGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        totalPoints.text = points.ToString();
    }

    public void AddPoints()
    {
        points++;
        currentPoints.text = "Points:" + points.ToString();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
