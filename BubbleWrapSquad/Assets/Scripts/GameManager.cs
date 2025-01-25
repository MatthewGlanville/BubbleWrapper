using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] Texture2D cursorTex;
    private Vector2 cursorHotSpot;
    [SerializeField] private Sprite unpoppedBubble;
    [SerializeField] private Sprite poppedBubble;
    [SerializeField] private Sprite hoveredBubble;
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

    public List<GameObject> bubbles; //loads the
    // Start is called before the first frame update
    void Awake()
    {
        cursorHotSpot = new Vector2(cursorTex.width / 2, cursorTex.height / 2);
        Cursor.SetCursor(cursorTex,cursorHotSpot, CursorMode.Auto);
        for (int i = 0; i < bubbles.Count; i++)
        {
            bubbleMap[i/16,i%16] = bubbles[i];
            PoppableBubble bubble = bubbles[i].GetComponent<PoppableBubble>();
            if (bubble != null)
            {
                bubble.bubblePos = i;
            }
        }
    }
    public void popBubbles(List<int> bubblepops)
    {
        foreach (int bubble in bubblepops)
        {
            int bubbleLength = bubble % 16;
            int bubbleHeight = bubble / 16;
            PoppableBubble bubbleScript= bubbleMap[bubbleHeight, bubbleLength].GetComponent<PoppableBubble>();
            if ((bubbleScript != null) && (!bubbleScript.Popped))
            {
                bubbleMap[bubbleHeight, bubbleLength].GetComponent<Image>().sprite = poppedBubble;
                bubbleScript.Popped = true;
            }
        }
        if (checkIfSolved())
        {
            SceneManager.LoadScene("WinScene");//REPLACE THIS WITH WHATEVER MENU SCENE YOU MAKE.
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void hover(List<int> bubblepops)
    {
        foreach (int bubble in bubblepops)
        {

            int bubbleLength = bubble % 16;
            int bubbleHeight = bubble / 16;
            PoppableBubble bubbleScript = bubbleMap[bubbleHeight, bubbleLength].GetComponent<PoppableBubble>();
            if ((bubbleScript != null) && (!bubbleScript.Popped))
            {
                bubbleMap[bubbleHeight, bubbleLength].GetComponent<Image>().sprite = hoveredBubble;
            }
        }

    }
    public void exitHover(List<int> bubblepops)
    {
        foreach (int bubble in bubblepops)
        {
            int bubbleLength = bubble % 16;
            int bubbleHeight = bubble / 16;
            PoppableBubble bubbleScript = bubbleMap[bubbleHeight, bubbleLength].GetComponent<PoppableBubble>();
            if ((bubbleScript != null) && (!bubbleScript.Popped))
            {
                bubbleMap[bubbleHeight, bubbleLength].GetComponent<Image>().sprite = unpoppedBubble;
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
