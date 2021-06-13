using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    // Start is called before the first frame update
    private float direction = 1;
    private float LerpValue = 0.0f;
    public float angle = 20f;
    public Vector3 startRotation;
    public float lerpOffset = 0;
    void Start()
    {
        startRotation = transform.rotation.eulerAngles;
        LerpValue = lerpOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float rotationZ = EasingFunction.Spring(0.0f, angle * direction, LerpValue);
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotationZ + startRotation.z));
        LerpValue += Time.deltaTime; 
        if (LerpValue > 1.0f)
        {
            LerpValue = 0.0f;
            direction *= -1.0f;
        }
    }
}
