using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Basket : MonoBehaviour
{
    public P1ScoreCounter scoreCounter;

    void Start()
    {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("P1ScoreCounter");      
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<P1ScoreCounter>();          
    }

    void OnCollisionEnter(Collision coll)
    {                           
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;                        
        if (collidedWith.CompareTag("Apple"))
        {                         
            Destroy(collidedWith);
            // Increase the score
            scoreCounter.score += 100;
            P1HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }
    }
}
