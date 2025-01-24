using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject [,] BubbleMap = { //a map full of all the bubbles in the scene, you cam 
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
        for (int i = 0; i < objects.Count; i++)
        {
            BubbleMap[i/16,i%16] = objects[i];
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
            PoppableBubble bubbleScript = BubbleMap[bubbleHeight,bubbleLength].GetComponent<PoppableBubble>();
            if (bubbleScript != null)
            {
                bubbleScript.popBubble();
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
