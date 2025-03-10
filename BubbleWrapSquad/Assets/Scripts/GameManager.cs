using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 
public class GameManager : MonoBehaviour
{
    //pop Sound Effect by <a href="https://pixabay.com/users/u_iozlfd2w96-48029382/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=283674">u_iozlfd2w96</a> from <a href="https://pixabay.com/sound-effects//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=283674">Pixabay</a>
    //menu music by Music by <a href="https://pixabay.com/users/geoffharvey-9096471/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=150622">Geoff Harvey</a> from <a href="https://pixabay.com/music//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=150622">Pixabay</a>
    //pop Sound Effect by <a href="https://pixabay.com/users/freesound_community-46691455/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=43207">freesound_community</a> from <a href="https://pixabay.com/sound-effects//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=43207">Pixabay</a>
    //game music by Music by <a href="https://pixabay.com/users/goldensoundlabs-31886162/?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=286273">Golden Sound Labs</a> from <a href="https://pixabay.com//?utm_source=link-attribution&utm_medium=referral&utm_campaign=music&utm_content=286273">Pixabay</a>
    [SerializeField] Texture2D cursorTex;
    private Vector2 cursorHotSpot;
    [SerializeField] private Sprite unpoppedBubble;
    [SerializeField] private Sprite poppedBubble;
    [SerializeField] private GameObject poppingBubble;
    [SerializeField] private Sprite hoveredBubble;
    [SerializeField] private Sprite unpoppedNonBubble;
    [SerializeField] private Sprite poppedNonBubble;
    [SerializeField] private GameObject poppingNonBubble;
    [SerializeField] private Sprite hoveredNonBubble;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int mapLength;
    [SerializeField] private int mapHeight;
    [SerializeField] private int level;
    private int score;
    public GameObject [,] bubbleMap = { //a map full of all the bubbles in the scene, you cam 
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
    };
    public List<List<GameObject>> bubbleMapDyn= new List<List<GameObject>>(); //not necessary just wanted to see if i could make it flexible cause i had nothing better to do
    [SerializeField] private AudioSource audio;
    [SerializeField] private List<AudioSource> bubbleSounds;
    GameObject popClone;
    public List<GameObject> bubbles; //loads the
    // Start is called before the first frame update
    void Awake()
    {
        score = mapHeight * mapLength;
        scoreText.text = "Bubbles: " + score;
        for (int x=0; x < mapHeight; x++)
        {
            List<GameObject> emptyList = new List<GameObject>();
            for (int y=0; y<mapLength; y++)
            {
                emptyList.Add(null);
            }
            bubbleMapDyn.Add(emptyList);
        }
        cursorHotSpot = new Vector2(cursorTex.width / 2, cursorTex.height / 2);
        Cursor.SetCursor(cursorTex,cursorHotSpot, CursorMode.Auto);
        for (int i = 0; i < bubbles.Count; i++)
        {
            bubbleMapDyn[i/mapLength][i%mapLength] = bubbles[i];
            PoppableBubble bubble = bubbles[i].GetComponent<PoppableBubble>();
            if (bubble != null)
            {
                bubble.bubblePos = i;
            }
        }
    }
    public void popBubbles(List<int> bubblepops)
    {
        int randNum = Random.Range(0,bubbleSounds.Count);
        bubbleSounds[randNum].Play();
        foreach (int bubble in bubblepops)
        {
            int bubbleLength = bubble % mapLength;
            int bubbleHeight = bubble / mapLength;
            PoppableBubble bubbleScript= bubbleMapDyn[bubbleHeight][bubbleLength].GetComponent<PoppableBubble>();
            if ((bubbleScript != null) && (!bubbleScript.Popped))
            {
                score -= 1;
                if (bubbleScript.Poppable)
                {
                    bubbleMapDyn[bubbleHeight][bubbleLength].SetActive(false);
                    popClone = Instantiate(poppingBubble, bubbleMapDyn[bubbleHeight][bubbleLength].transform.position, Quaternion.identity);
                    PopScript pop = popClone.GetComponent<PopScript>();
                    if (pop != null)
                    {
                        pop.popStart(this, bubbleMapDyn[bubbleHeight][bubbleLength]);
                    }

                }
                else
                {
                    bubbleMapDyn[bubbleHeight][bubbleLength].SetActive(false);
                    popClone = Instantiate(poppingNonBubble, bubbleMapDyn[bubbleHeight][bubbleLength].transform.position, Quaternion.identity);
                    PopScript pop = popClone.GetComponent<PopScript>();
                    if (pop != null)
                    {
                        pop.popStart(this, bubbleMapDyn[bubbleHeight][bubbleLength]);
                    }
                }
                bubbleScript.Popped = true;
            }
            
        }
        scoreText.text = "Bubbles: " + score;
        if (checkIfSolved())
        {
            if (level == 1)
            {
                PlayerPrefs.SetInt("level1", 1);
            }
            if (level == 2)
            {
                PlayerPrefs.SetInt("level2", 1);
            }
            if (level == 3)
            {
                PlayerPrefs.SetInt("level3", 1);
            }
            SceneManager.LoadScene("MainMenu");//REPLACE THIS WITH WHATEVER MENU SCENE YOU MAKE.
        }
    }
    public void getPopped(GameObject bubbleObj)
    {
        bubbleObj.SetActive(true);
        bubbleObj.GetComponent<Image>().sprite = poppedBubble;
        PoppableBubble bubbleScript = bubbleObj.GetComponent<PoppableBubble>();
        if ((bubbleScript != null))
        {
            if (bubbleScript.Poppable)
            {
                bubbleObj.GetComponent<Image>().sprite = poppedBubble;
            }
            else
            {
                bubbleObj.GetComponent<Image>().sprite = poppedNonBubble;
            }
        }
    }
    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void hover(List<int> bubblepops)
    {
        foreach (int bubble in bubblepops)
        {

            int bubbleLength = bubble % mapLength;
            int bubbleHeight = bubble / mapLength;
            PoppableBubble bubbleScript = bubbleMapDyn[bubbleHeight][bubbleLength].GetComponent<PoppableBubble>();
            if ((bubbleScript != null) && (!bubbleScript.Popped))
            {
                if (bubbleScript.Poppable)
                {
                    bubbleMapDyn[bubbleHeight][bubbleLength].GetComponent<Image>().sprite = hoveredBubble;
                }
                else
                {
                    bubbleMapDyn[bubbleHeight][bubbleLength].GetComponent<Image>().sprite = hoveredNonBubble;
                }
            }
        }

    }
    public void exitHover(List<int> bubblepops)
    {
        foreach (int bubble in bubblepops)
        {
            int bubbleLength = bubble % mapLength;
            int bubbleHeight = bubble / mapLength;
            PoppableBubble bubbleScript = bubbleMapDyn[bubbleHeight][bubbleLength].GetComponent<PoppableBubble>();
            if ((bubbleScript != null) && (!bubbleScript.Popped))
            {
                if (bubbleScript.Poppable)
                {
                    bubbleMapDyn[bubbleHeight][bubbleLength].GetComponent<Image>().sprite = unpoppedBubble;
                }
                else
                {
                    bubbleMapDyn[bubbleHeight][bubbleLength].GetComponent<Image>().sprite = unpoppedNonBubble;
                }
            }
        }

    }
    bool checkIfSolved()
    {
        for (int i=0; i<bubbles.Count; i++)
        {
            PoppableBubble bubbleScript = bubbles[i].GetComponent<PoppableBubble>();
            if (( bubbleScript != null ) && (!bubbleScript.Popped)){
                return false;
            }
        }
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
