using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storm : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Inscribed")]                                               
    // Prefab for instantiating rain
    public GameObject rainPrefab;

    // Speed at which the Storm moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between rain instantiations
    public float rainDropDelay = 1f;

    void Start()
    {
        // Start dropping rain
        Invoke("DropRain", 2f);                                    
    }

    void DropRain()
    {                                                    
        GameObject rain = Instantiate<GameObject>(rainPrefab);      
        rain.transform.position = transform.position;                   
        Invoke("DropRain", rainDropDelay);                           
    }

    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;                       
        pos.x += speed * Time.deltaTime;                         
        transform.position = pos;
        // Changing Direction

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);   // Move right                         
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);  // Move left                           
        }
        // else if (Random.value < changeDirChance)
        //{
        // speed *= -1;  // Change direction 
        //}
    }

    void FixedUpdate()
    {                                               
        // Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance)
        {                        
            speed *= -1; // Change direction 
        }
    }
}
