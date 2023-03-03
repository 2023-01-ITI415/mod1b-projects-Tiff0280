using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;
    public int distance = -10;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, distance);
    }

}

