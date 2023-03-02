using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHit : MonoBehaviour
{
    // A static field accessible by code anywhere
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        // When the trigger is hit by something
        // Check to see if it’s a Projectile
        Box proj = other.GetComponent<Box>();                    // a
        if (proj != null)
        {
            // If so, set goalMet to true
            Goal.goalMet = true;
            // Also set the alpha of the color to higher opacity
            Material mat = GetComponent<Renderer>().material;                  // b
            Color c = mat.color;
            c.a = 0.75f;
            mat.color = c;
        }
    }
}
