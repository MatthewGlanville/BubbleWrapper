using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppableBubble : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<int> bubblepops;
    public int bubblePos;
    private bool popped = false; 
    public bool Popped
    {
        get { return popped; }
        set { popped = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        bubblepops[0] = bubblePos;
    }
    public void OnClick()
    {
        if (!Popped)
        {
            gameManager.popBubbles(bubblepops);
        }
    }
    public void OnHover()
    {
        Debug.Log("waaa");
        if (!Popped)
        {
            gameManager.hover(bubblepops);
        }
    }
    public void OnExitHover()
    {
        if (!Popped)
        {
            gameManager.exitHover(bubblepops);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
