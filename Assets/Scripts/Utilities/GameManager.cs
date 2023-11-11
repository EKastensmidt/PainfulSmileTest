using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void OnEnable()
    {
        PlayerController.OnPlayerPauseGame += OpenPauseGameMenu;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerPauseGame -= OpenPauseGameMenu;
    }

    public void OpenPauseGameMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
    }
}
