using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployBubbles : MonoBehaviour
{
    public GameObject bubblePowerUpPrefab;
    public float respawnTime = 1.0f;
    public Transform bubblepowerupgenerator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BubblePowerUpWave());
    }

    private void spawnPowerUpBubble()
    {
        GameObject bubblePowerUp = Instantiate(bubblePowerUpPrefab) as GameObject;
        bubblePowerUp.transform.position =new Vector3(Random.Range(4, -4),-10,-9);
    }
    IEnumerator BubblePowerUpWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPowerUpBubble();
        }

    }


    
    // Update is called once per frame
    void Update()
    {
        
    }
}
