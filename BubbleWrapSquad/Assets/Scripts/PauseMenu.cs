/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu: MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject volumeMenu;
    //public SceneSwitcher SceneSwitcher;
    //public VolumeController volumeController;
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Home()
    {
        //ScoreManager.Instance.CheckHighScore();
        //SceneSwitcher.LoadSceneByName("MainMenu");
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        //ScoreManager.Instance.CheckHighScore();
        //SceneSwitcher.LoadSceneByName("GameScene");
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
        //volumeMenu.SetActive(true);
        //volumeController.HandleAudio();
    }

    public void VolumeInactive()
    {
        Time.timeScale = 0f;
        //volumeController.SaveSettings();
        //volumeMenu.SetActive(false);
    }
}*/