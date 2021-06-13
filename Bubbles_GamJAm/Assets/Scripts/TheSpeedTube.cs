using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSpeedTube : MonoBehaviour
{

    public Bubble playerBubble;
    [Range(0, 100)]
    public float superFloatValue;
    private float initalFloatValue; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerBubble.GoSuperSpeed();
            //initalFloatValue = playerBubble.floating;
            //playerBubble.floating = initalFloatValue * 1.5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerBubble.ReturnToNormalSpeed();
        }
    }
}