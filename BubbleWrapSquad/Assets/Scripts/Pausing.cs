using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing: MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject volumeMenu;
    [SerializeField]
    Switcher SceneSwitcher;
    [SerializeField]
    Volume volumeController;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Home()
    {
        //ScoreManager.Instance.CheckHighScore();
        SceneSwitcher.LoadSceneByName("MainMenu");
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        //ScoreManager.Instance.CheckHighScore();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void VolumeActive()
    {
        Time.timeScale = 0f;
        volumeMenu.SetActive(true);
        volumeController.HandleAudio();
    }

    public void VolumeInactive()
    {
        Time.timeScale = 0f;
        volumeController.SaveSettings();
        volumeMenu.SetActive(false);
    }
}