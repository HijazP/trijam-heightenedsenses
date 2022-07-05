using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static bool paused = false;
    public GameObject pauseUI;
    public GameObject pauseButton;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void TitleScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title Screen");
    }
}
