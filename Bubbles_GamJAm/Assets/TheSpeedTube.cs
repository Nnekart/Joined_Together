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
            initalFloatValue = playerBubble.floating;
            playerBubble.floating = superFloatValue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerBubble.floating = initalFloatValue + 3.0f;
    }
}
