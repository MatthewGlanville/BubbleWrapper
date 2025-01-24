using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppableBubble : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<int> bubblepops;
    public int bubblePos; 
    // Start is called before the first frame update
    void Start()
    {
        bubblepops[0] = bubblePos;
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
