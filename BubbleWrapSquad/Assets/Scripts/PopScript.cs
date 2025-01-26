using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopScript : MonoBehaviour
{
    private GameManager manager;
    private GameObject bubble; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void popStart(GameManager manager,GameObject bubble)
    {
        this.manager = manager;
        this.bubble = bubble;
    }
    public void popEnd()
    {
        manager.getPopped(bubble);
        Destroy(this.gameObject);
    }
    public void autoPop()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
