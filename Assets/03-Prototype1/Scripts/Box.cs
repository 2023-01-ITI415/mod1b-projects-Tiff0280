using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public CurrentScore currentScore;

    void Start()
    {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("CurrentScore");
        // Get the ScoreCounter (Script) component of scoreGO
        currentScore = scoreGO.GetComponent<CurrentScore>();
        
    }

    void OnCollisionEnter(Collision coll)
    {                             // a
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Rain"))
        {                         // c
            Destroy(collidedWith);
            // Decrease the score
            currentScore.score -= 100;

            // Get a reference to the ApplePicker component of Main Camera
            StormDrop apScript = Camera.main.GetComponent<StormDrop>();           // b
            // Call the public AppleMissed() method of apScript
            apScript.RainCollected();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
            currentScore.score += 100;
            HighestScore.TRY_SET_HIGH_SCORE(currentScore.score);
        }
    }



}
