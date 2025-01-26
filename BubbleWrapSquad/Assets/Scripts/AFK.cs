using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFK : MonoBehaviour
{
    Vector3 lastMouseCoord;
    [SerializeField] private float AFKTime;
    [SerializeField] private float spawnTime;
    [SerializeField] private GameObject autoPopBubble; //i was bored so i made this. 
    private float AFKTimer;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        lastMouseCoord = Input.mousePosition;
        AFKTimer = AFKTime; 
        spawnTimer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        AFKTimer-=Time.deltaTime;
        if (Input.mousePosition != lastMouseCoord)
        {
            AFKTimer = AFKTime;
            spawnTimer = spawnTime;
        }
        if (AFKTimer <= 0)
        {
            spawnTimer-=Time.deltaTime;
            if (spawnTimer <= 0)
            {
                Instantiate(autoPopBubble,this.transform.position,Quaternion.identity);
                spawnTimer= spawnTime;
            }
        }
        lastMouseCoord=Input.mousePosition;
    }
}
