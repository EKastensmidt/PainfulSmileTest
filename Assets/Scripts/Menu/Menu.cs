using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu, optionsMenu;

    public void Play()
    {
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
        optionsMenu.SetActive(false);
        menu.SetActive(true);
    }
}
