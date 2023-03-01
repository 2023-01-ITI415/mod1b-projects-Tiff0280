using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{


    void OnCollisionEnter(Collision coll)
    {                             // a
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;                        
        if (collidedWith.CompareTag("Rain"))
        {                         // c
            Destroy(collidedWith);
        }
    }

}
