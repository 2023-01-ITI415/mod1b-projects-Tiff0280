using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormDrop : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject boxPrefab;
    public int numBox = 3;
    public float boxBottomY = -9f;
    public float boxSpacingY = 2f;

    void Start()
    {
        for (int i = 0; i < numBox; i++)
        {
            GameObject tBoxGO = Instantiate<GameObject>(boxPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = boxBottomY + (boxSpacingY * i);
            tBoxGO.transform.position = pos;
        }
    }
}
