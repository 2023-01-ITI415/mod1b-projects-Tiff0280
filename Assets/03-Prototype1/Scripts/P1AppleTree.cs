using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1AppleTree : MonoBehaviour
{
    [Header("Inscribed")]                                                  
    // Prefab for instantiating apples
    public GameObject applePrefab;
 
    // Speed at which the AppleTree moves
    public float speed = 1f;
 
    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;
 
    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    void Start()
    {
        // Start dropping apples                                          
    }

    void Update()
    {
        // Basic Movement                                                  
        // Changing Direction  
    }
}
