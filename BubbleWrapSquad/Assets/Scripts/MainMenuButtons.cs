using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject largeButton;
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
        easyButton.SetActive(true);
        mediumButton.SetActive(true);
        largeButton.SetActive(true);
    }
    public void optionbutton()
    {

    }
    public void exitbutton()
    {
       Application.Quit();
    }

    public void easy()
    {
        SceneManager.LoadScene("BeginnerLevel");
    }
    public void medium() 
    {
        SceneManager.LoadScene("MediumLevel");
    }
    public void large() 
    {
        SceneManager.LoadScene("MainGame");
    }
}
