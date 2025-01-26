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
    [SerializeField] private AudioSource menuClick;
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
        menuClick.Play();
        easyButton.SetActive(true);
        mediumButton.SetActive(true);
        largeButton.SetActive(true);
    }
    public void optionbutton()
    {
        menuClick.Play();
    }
    public void exitbutton()
    {
        menuClick.Play();
        Application.Quit();
    }

    public void easy()
    {
        menuClick.Play();
        SceneManager.LoadScene("BeginnerLevel");
    }
    public void medium() 
    {
        menuClick.Play();
        SceneManager.LoadScene("MediumLevel");
    }
    public void large() 
    {
        menuClick.Play();
        SceneManager.LoadScene("MainGame");
    }
    public void Trophy()
    {
        menuClick.Play();
        SceneManager.LoadScene("TrophyRoom");
    }
}
