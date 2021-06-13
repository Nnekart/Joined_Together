using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployBubbles : MonoBehaviour
{
    public GameObject bubblePowerUpPrefab;
    public float respawnTime = 1.0f;
    public Transform bubblepowerupgenerator;
    private Rigidbody rb; 
    // Start is called before the first frame update

    private void Awake()
    {
    }
    void Start()
    {
        StartCoroutine(BubblePowerUpWave());
    }

    private void spawnPowerUpBubble()
    {
        GameObject bubblePowerUp = Instantiate(bubblePowerUpPrefab) as GameObject;
        bubblePowerUp.transform.position = new Vector3(Random.Range(4, -4),transform.position.y,transform.position.z);
        rb = bubblePowerUp.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, 1.0f, 0.0f);

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
