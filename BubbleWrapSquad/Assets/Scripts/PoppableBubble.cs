using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppableBubble : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<int> bubblepops;
    public int bubblePos;
    private bool popped = false;
    private bool poppable;
    public bool Poppable
    {
        get { return poppable; }
    }
    public bool Popped
    {
        get { return popped; }
        set { popped = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        bubblepops[0] = bubblePos;
        if (bubblepops.Count > 1)
        {
            poppable = true;
        }
        else
        {
            poppable = false;
        }
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
