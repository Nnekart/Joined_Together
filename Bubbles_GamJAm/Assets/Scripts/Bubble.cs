using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    public float floating;
    public float MovementSpeed;
    public float deflateRate;
    public Rigidbody Rb;
    public float speedModifier = 100;
    public float superspeed = 200;
    private bool isSuperspeed = false;
    public float minScale = 0.2f;
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float speed = transform.localScale.magnitude - 1;
        // Physics.gravity = new Vector3(0,floating,0);
        //Rb.AddForce(transform.up * floating);
        if (isSuperspeed)
        {
            Rb.AddForce(transform.up * speed * Time.deltaTime * superspeed);

        }
        else
        {
            Rb.AddForce(transform.up * speed * Time.deltaTime * speedModifier);

        }
        var movement = -Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;
        transform.localScale += new Vector3(-deflateRate * Time.deltaTime, -deflateRate * Time.deltaTime, -deflateRate * Time.deltaTime);
        
        if (transform.localScale.magnitude < minScale)
        {
            float factor = minScale / transform.localScale.magnitude;

            transform.localScale *= factor;
        }
    }

    public void Shrink()
    {
        transform.localScale /= 1.4f;
    }

    public void GoSuperSpeed()
    {
        isSuperspeed = true;
    }

    public void ReturnToNormalSpeed()
    {
        isSuperspeed = false;
    }


}
