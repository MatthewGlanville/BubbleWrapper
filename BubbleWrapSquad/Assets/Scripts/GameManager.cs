using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Sprite popped; 
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
            bubbleMap[bubbleHeight, bubbleLength].GetComponent<Image>().sprite = popped;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
