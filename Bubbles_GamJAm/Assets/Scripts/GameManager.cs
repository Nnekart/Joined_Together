using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static string nameOfLevel = "BubbleGame";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void RestartScene()
    {
        SceneManager.LoadScene(nameOfLevel);
    }

    public static void Quit()
    {
        Application.Quit();
    }
}
