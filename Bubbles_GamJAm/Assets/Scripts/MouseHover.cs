using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MouseHover : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Effect
    {
        rotating, 
        changeText,
    }

    public bool isStart;
    public bool isQuit;
    public Effect effect;
    [Range(0,1)]
    public float Speed;
    private Transform initialTransform;
    public Transform textTransform;
    public TextMeshPro textMesh; 

    bool isActive = false;
    bool isRotating = false;
    private float amount;
    public string[] texts;
    private float timePerText;
    private float fastSpeed = 6;
    private float spinnyNess; 
    private void Awake()
    {
    }
    void Start()
    {
        initialTransform = textTransform;
        if (effect == Effect.changeText) textMesh = GetComponent<TextMeshPro>();

    }

    // Update is called once per frame
    void Update()
    {
        amount += Time.deltaTime * Speed;
        if (amount > 1)
        {
            amount = 0;
            isRotating = false;
            spinnyNess = 0;
        }

        switch (effect)
        {
            case (Effect.rotating):
                if (isRotating)
                {
                    float newSpeed = Mathf.Lerp(fastSpeed, 0, amount);
                    spinnyNess += newSpeed * Time.deltaTime;
                    Vector3 rotationAmount = new Vector3(spinnyNess * 360 + 90.0f, 0.0f, 0.0f);
                    textTransform.rotation = Quaternion.Euler(rotationAmount);
                    textMesh.color = Color.blue;

                }
                else
                {
                    Vector3 rotationAmount = new Vector3(90.0f, 0.0f, 0.0f);
                    textTransform.rotation = Quaternion.Euler(rotationAmount);
                    textMesh.color = Color.black;
                    //   textTransform.rotation = initialTransform.rotation;
                    amount = 0;
                }
                break;
            case (Effect.changeText):
                if (isActive)
                {
                    int currentTextLine = Mathf.FloorToInt(amount * texts.Length);
                    if (currentTextLine == 0) currentTextLine = 1;
                    textMesh.SetText(texts[currentTextLine]);
                    textMesh.color = Color.green;
                }
                else
                {
                    textMesh.color = Color.gray;
                    textMesh.SetText(texts[0]);
                }
                break;
        }

    }

    private void OnMouseEnter()
    {
        amount = 0;
        isActive = true;
        isRotating = true;
        spinnyNess = 0;


    }

    private void OnMouseExit()
    {
        amount = 0;
        isActive = false;
    }

    private void OnMouseUp()
    {
        if (isStart)
        {
            GameManager.RestartScene();
        } else if (isQuit)
        {
            GameManager.Quit();
        }
    }
}
