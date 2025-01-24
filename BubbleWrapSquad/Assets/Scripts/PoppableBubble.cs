using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppableBubble : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<int> bubblepops;
    // Start is called before the first frame update
    void Start()
    {
        int bubbleLength = bubblepops[0] % 16;
        int bubbleHeight = bubblepops[0] / 16;
        gameManager.BubbleMap[bubbleLength, bubbleHeight] = gameObject;
        Debug.Log(gameManager.BubbleMap[bubbleLength, bubbleHeight] + "njfrnijfenij");
    }
    public void OnClick()
    {
        gameManager.popBubbles(bubblepops);
    }
    public void popBubble()
    {
        Debug.Log(bubblepops[0]);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
