using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPopBubble : MonoBehaviour //this script was conjured out of boredom, it only happens when you arent playing the game for too long.
{
    // Start is called before the first frame update
    [SerializeField] private GameObject poppingBubble;
    private float lifeTime;
    private float xSpeed;
    private float ySpeed;
    void Start()
    {
        lifeTime = Random.Range(2, 5);
        xSpeed = (Random.Range(-100, 100) / 10);
        ySpeed = Random.Range(3, 6);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(xSpeed, ySpeed, 0)*Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Instantiate(poppingBubble,this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
