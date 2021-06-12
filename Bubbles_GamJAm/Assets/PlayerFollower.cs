using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;

    private float previousPlayerY;
    private float currentPlayerY;

    public float cameraShiftTime;
    private float timeToCameraShift = 0.1f;
    private float lerpValue; 
    void Start()
    {
        previousPlayerY = player.position.y;
        currentPlayerY = player.position.y;
        cameraShiftTime = timeToCameraShift;
        lerpValue = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraShiftTime < 0)
        {
            

            cameraShiftTime = timeToCameraShift;
            previousPlayerY = currentPlayerY;
            currentPlayerY = player.position.y;
        }
        else
        {
            lerpValue = (1.0f - cameraShiftTime / timeToCameraShift);
            float yPosition = Mathf.Lerp(previousPlayerY, currentPlayerY, lerpValue);
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);

            cameraShiftTime -= Time.deltaTime;
        }

    }
}
