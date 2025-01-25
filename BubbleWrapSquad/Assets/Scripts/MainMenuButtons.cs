using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject largeButton;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip menuClick;
    // Start is called before the first frame update
    void Start()
    {
        easyButton.SetActive(false);
        mediumButton.SetActive(false);
        largeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playbutton()
    {
        audio.PlayOneShot(menuClick);
        easyButton.SetActive(true);
        mediumButton.SetActive(true);
        largeButton.SetActive(true);
    }
    public void optionbutton()
    {
        audio.PlayOneShot(menuClick);
    }
    public void exitbutton()
    {
        audio.PlayOneShot(menuClick);
        Application.Quit();
    }

    public void easy()
    {
        audio.PlayOneShot(menuClick);
        SceneManager.LoadScene("BeginnerLevel");
    }
    public void medium() 
    {
        audio.PlayOneShot(menuClick);
        SceneManager.LoadScene("MediumLevel");
    }
    public void large() 
    {
        audio.PlayOneShot(menuClick);
        SceneManager.LoadScene("MainGame");
    }
}
