using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject [,] BubbleMap = {
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
        {null, null,null,null,null, null,null,null,null, null,null,null,null, null,null,null},
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void popBubbles(List<int> bubblepops)
    {
        foreach (int bubble in bubblepops)
        {
            int bubbleLength = bubble % 16;
            int bubbleHeight = bubble / 16;
            PoppableBubble bubbleScript = BubbleMap[bubbleLength,bubbleHeight].GetComponent<PoppableBubble>();
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
