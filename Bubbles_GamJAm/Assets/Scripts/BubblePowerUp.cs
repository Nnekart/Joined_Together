using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePowerUp : MonoBehaviour
{
    public GameObject Bubble;
    public float increaseInBubbleSize;
    public Bubble bubbleScript;
    public Rigidbody Rb;
    public float PowerUpSpeed;


    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            bubbleScript.floating += 0.5f;
            Rb.AddForce(transform.up * PowerUpSpeed);
            //Physics.gravity = new Vector3(0, 5f, 0);
            Bubble.transform.localScale += new Vector3(increaseInBubbleSize, increaseInBubbleSize, increaseInBubbleSize);
            Destroy(this.gameObject);
        }


    }

    private void DeathAfterTime()
    {
        Destroy(this.gameObject, 20f);
    }

}