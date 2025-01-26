using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausing : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject volumeMenu;
    [SerializeField]
    Switcher SceneSwitcher;
    [SerializeField]
    Volume volumeController;
    [SerializeField] AudioSource menuClick;
    public void Pause()
    {
        menuClick.Play();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Home()
    {
        menuClick.Play();
        SceneSwitcher.LoadSceneByName("MainMenu");
        Time.timeScale = 1f;
    }
    public void Resume()
    {
        menuClick.Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void Restart()
    {
        menuClick.Play();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1f;
    }
    public void VolumeActive()
    {
        menuClick.Play();
        Time.timeScale = 0f;;
        volumeMenu.SetActive(true);
        volumeController.HandleAudio();
    }

    public void VolumeInactive()
    {
        menuClick.Play();
        Time.timeScale = 0f;
        volumeController.SaveSettings();
        volumeMenu.SetActive(false);
    }
}
