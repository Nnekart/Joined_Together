using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    public float floating;
    public float MovementSpeed;
    public float deflateRate;

    void Update()
    {
        Physics.gravity = new Vector3(0,-floating,0);
        var movement = -Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * MovementSpeed;
        transform.localScale += new Vector3(-deflateRate * Time.deltaTime, -deflateRate * Time.deltaTime, -deflateRate * Time.deltaTime);
        
    }


}
