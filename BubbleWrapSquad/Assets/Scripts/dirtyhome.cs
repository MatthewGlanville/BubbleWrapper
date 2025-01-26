using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dirtyhome : MonoBehaviour
{
    public GameObject trophy1;
    public GameObject trophy2;
    public GameObject mug1;
    public GameObject mug2;
    public GameObject figure1;
    public GameObject figure2;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("level1") == 0)
        {
            trophy1.SetActive(false);
            trophy2.SetActive(true);
        }
        else
        {
            trophy1.SetActive(true);
            trophy2.SetActive(false);
        }

        if (PlayerPrefs.GetInt("level2") == 0)
        {
            mug1.SetActive(false);
            mug2.SetActive(true);
        }
        else
        {
            mug1.SetActive(true);
            mug2.SetActive(false);
        }

        if (PlayerPrefs.GetInt("level3") == 0)
        {
            figure1.SetActive(false);
            figure2.SetActive(true);
        }
        else
        {
            figure1.SetActive(true);
            figure2.SetActive(false);
        }
    }
        // Update is called once per frame
    void Update()
    {
        
         
    }

    public void homy()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
