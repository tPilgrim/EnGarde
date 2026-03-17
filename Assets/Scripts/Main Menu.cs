using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerVSPlayer()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void PlayerVSComputer()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
