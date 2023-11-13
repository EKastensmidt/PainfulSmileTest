using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int points;
    private GameObject player;
    private float currentTime;
    //UI
    [SerializeField] private GameObject pauseMenu, gameOverScreen;
    [SerializeField] private TextMeshProUGUI currentPoints, totalPoints, timeLeft;

    private void Start()
    {
        if (PlayerPrefs.HasKey("GameSessionTime"))
        {
            currentTime = PlayerPrefs.GetInt("GameSessionTime") * 60;
        }
        else
        {
            currentTime = 180f;
        }

        timeLeft.text = currentTime.ToString();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player == null)
            return;

        SetTime();
    }

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

    private int minutes, seconds;

    private void SetTime()
    {
        if (currentTime <= 0)
        {
            OpenGameOverScreen();
            Destroy(player);
        }

        currentTime -= Time.deltaTime;
        minutes = (int)(currentTime / 60f);
        seconds = (int)(currentTime - minutes * 60f);

        UpdateTime(minutes, seconds);
    }

    private void UpdateTime(int minutes, int seconds)
    {
        timeLeft.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
