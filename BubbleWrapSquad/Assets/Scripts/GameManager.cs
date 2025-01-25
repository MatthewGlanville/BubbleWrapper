using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; 
public class GameManager : MonoBehaviour
{
    [SerializeField] Texture2D cursorTex;
    private Vector2 cursorHotSpot;
    [SerializeField] private Sprite unpoppedBubble;
    [SerializeField] private Sprite poppedBubble;
    [SerializeField] private Sprite hoveredBubble;
    [SerializeField] private Sprite unpoppedNonBubble;
    [SerializeField] private Sprite poppedNonBubble;
    [SerializeField] private Sprite hoveredNonBubble;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int mapLength;
    [SerializeField] private int mapHeight;
    //private int score;
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
    [SerializeField] private List<AudioClip> bubbleSounds;

    public List<GameObject> bubbles; //loads the
    // Start is called before the first frame update
    void Awake()
    {
       //score = mapHeight * mapLength;
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
        audio.PlayOneShot(bubbleSounds[randNum]);
        //score -= bubblepops.Count;
        //scoreText.text = "Score: " + score; 
        foreach (int bubble in bubblepops)
        {
            int bubbleLength = bubble % mapLength;
            int bubbleHeight = bubble / mapLength;
            PoppableBubble bubbleScript= bubbleMapDyn[bubbleHeight][bubbleLength].GetComponent<PoppableBubble>();
            if ((bubbleScript != null) && (!bubbleScript.Popped))
            {
                if (bubbleScript.Poppable)
                {
                    bubbleMapDyn[bubbleHeight][bubbleLength].GetComponent<Image>().sprite = poppedBubble;
                }
                else
                {
                    bubbleMapDyn[bubbleHeight][bubbleLength].GetComponent<Image>().sprite = poppedNonBubble;
                }
                bubbleScript.Popped = true;
            }
        }
        if (checkIfSolved())
        {
            SceneManager.LoadScene("MainMenu");//REPLACE THIS WITH WHATEVER MENU SCENE YOU MAKE.
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
