using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{

    public enum HorizontalMovement {
        none,
        acrossAndBackA,
        acrossAndBackB, 
        acrossAndBackC,
        acrossAndBackDiscrete,
        bounceLeftWall,
        bounceRightWall,
        uncurl,
        stretch, 
    }

    public enum VerticalMovement {
        bounceDown, 
        bounceUp, 
        sinWave, 
        none, 
        stretch, 
    }
    public HorizontalMovement horizontalMovement;
    public VerticalMovement verticalMovement;
    [Range (0,2)]
    public float horizontalSpeed;
    [Range(0, 2)]
    public float verticalSpeed;
    [Range(0, 1)]
    public float bounceRange;
    [Range(0, 1)]
    public float wiggleRange;
    [Range(0, 100)]
    public float wiggleFrequency;
    [Range(0, 10)]
    public float stretchAmount; 

    public Transform positionA = null;
    public Transform positionB = null;
    private float xPositionA;
    private float xPositionB;
    private float yPositionA;
    private float yPositionB; 
    private float startingXPos;
    private float startingYPos;
    
    private float lerpValueHorizontal;
    private float lerpValueVertical;


    // Start is called before the first frame update
    private void Awake()
    {
        if (positionA != null)
        {
            xPositionA = positionA.position.x;
            yPositionA = positionA.position.y;
        }
        if (positionB != null)
        {
            xPositionB = positionB.position.x;
            yPositionB = positionB.position.y;
        }
       
        startingXPos = transform.position.x;
        startingYPos = transform.position.y;
    }

    private void Start()
    {
        lerpValueHorizontal = 0;
        lerpValueVertical = 0; 

    }
    // Update is called once per frame
    void Update()
    {

        lerpValueHorizontal += horizontalSpeed * Time.deltaTime;
        lerpValueHorizontal %= 2;
        float adjustedHorizontalLerp = Mathf.Abs(lerpValueHorizontal - 1);
        lerpValueVertical += verticalSpeed * Time.deltaTime;
        lerpValueVertical %= 2;
        float adjustedVerticalLerp = Mathf.Abs(lerpValueVertical - 1); 

        float newXValue = 0;
        float newYValue = 0;
        switch (horizontalMovement)
        {
            case HorizontalMovement.none: break;
            case HorizontalMovement.acrossAndBackA:
                transform.position = LerpWithXValue(adjustedHorizontalLerp);
                break;
            case HorizontalMovement.acrossAndBackB:
                newXValue = EasingFunction.EaseInOutSine(xPositionA, xPositionB, adjustedHorizontalLerp);
                transform.position =  new Vector3(newXValue, transform.position.y, transform.position.z);
                break;
            case HorizontalMovement.acrossAndBackC:

                break;
            case HorizontalMovement.acrossAndBackDiscrete:
                adjustedHorizontalLerp = Mathf.Floor(adjustedHorizontalLerp * 5.9f) / 5;
                transform.position = LerpWithXValue(adjustedHorizontalLerp);
                break;
            case HorizontalMovement.bounceLeftWall:
                adjustedHorizontalLerp = Mathf.Cos(adjustedHorizontalLerp * Mathf.PI / 2) * bounceRange;
                transform.position = LerpWithXValue(adjustedHorizontalLerp);
                break;
            case HorizontalMovement.bounceRightWall:
                adjustedHorizontalLerp = Mathf.Cos(adjustedHorizontalLerp * Mathf.PI / 2) * bounceRange;
                transform.position = ReverseLerpWithXValue(adjustedHorizontalLerp);
                
                break;
            case HorizontalMovement.uncurl:

                break;
            case HorizontalMovement.stretch:
                transform.localScale = new Vector3 (adjustedHorizontalLerp * stretchAmount, transform.localScale.y, transform.localScale.z);

                break;
        }
        switch (verticalMovement)
        {
            case VerticalMovement.none: break;
            case VerticalMovement.bounceDown:
                adjustedVerticalLerp = Mathf.Cos(adjustedVerticalLerp * Mathf.PI / 2) * bounceRange;
                transform.position = ReverseLerpWithYValue(adjustedVerticalLerp);

                break;
            case VerticalMovement.bounceUp:
                adjustedVerticalLerp = Mathf.Cos(adjustedVerticalLerp * Mathf.PI / 2) * bounceRange;
                transform.position = LerpWithYValue(adjustedVerticalLerp);

                break;
            case VerticalMovement.sinWave:
                newYValue = Mathf.Sin(adjustedHorizontalLerp * wiggleFrequency) * wiggleRange;
                transform.position = new Vector3(transform.position.x, startingYPos + newYValue, transform.position.z);
                break;
            case VerticalMovement.stretch:
                transform.localScale = new Vector3(transform.localScale.x, adjustedVerticalLerp * stretchAmount, transform.localScale.z);
                

                break;
        }
    }

    private Vector3 LerpWithYValue(float adjustedVerticalLerp)
    {
        float newYPosition = Mathf.Lerp(yPositionA, yPositionB, adjustedVerticalLerp);
        return new Vector3(transform.position.x, newYPosition, transform.position.z);

    }
    private Vector3 ReverseLerpWithYValue (float adjustedVerticalLerp)
    {
        float newYPosition = Mathf.Lerp(yPositionB, yPositionA, adjustedVerticalLerp);
        return new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
    private Vector3 ReverseLerpWithXValue(float adjustedHorizontalLerp)
    {
        float newXPosition = Mathf.Lerp(xPositionB, xPositionA, adjustedHorizontalLerp);
        return new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
    private Vector3 LerpWithXValue(float adjustedHorizontalLerp)
    {
        float newXPosition = Mathf.Lerp(xPositionA, xPositionB, adjustedHorizontalLerp);
        return new Vector3(newXPosition, transform.position.y, transform.position.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        GameManager.RestartScene();

    }
    
}
