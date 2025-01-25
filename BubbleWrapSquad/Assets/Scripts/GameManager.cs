using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] Texture2D cursorTex;
    private Vector2 cursorHotSpot;
    [SerializeField] private Sprite regular;
    [SerializeField] private Sprite popped;
    [SerializeField] private Sprite hovered;
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

    public List<GameObject> objects; 
    // Start is called before the first frame update
    void Start()
    {
        cursorHotSpot = new Vector2(cursorTex.width / 2, cursorTex.height / 2);
        Cursor.SetCursor(cursorTex,cursorHotSpot, CursorMode.Auto);
        for (int i = 0; i < objects.Count; i++)
        {
            bubbleMap[i/16,i%16] = objects[i];
            PoppableBubble bubble = objects[i].GetComponent<PoppableBubble>();
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
                bubbleMap[bubbleHeight, bubbleLength].GetComponent<Image>().sprite = popped;
                bubbleScript.Popped = true;
            }
        }

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
                bubbleMap[bubbleHeight, bubbleLength].GetComponent<Image>().sprite = hovered;
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
                bubbleMap[bubbleHeight, bubbleLength].GetComponent<Image>().sprite = regular;
            }
        }

    }
    bool checkIfSolved()
    {
        for (int i=0; i<objects.Count; i++)
        {
            PoppableBubble bubbleScript = objects[i].GetComponent<PoppableBubble>();
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
