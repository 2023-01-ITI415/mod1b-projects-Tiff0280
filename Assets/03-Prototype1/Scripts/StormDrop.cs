using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StormDrop : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject boxPrefab;
    public int numBox = 3;
    public float boxBottomY = -9f;
    public float boxSpacingY = 2f;
    public List<GameObject> boxList;

    void Start()
    {
        boxList = new List<GameObject>();
        for (int i = 0; i < numBox; i++)
        {
            GameObject tBoxGO = Instantiate<GameObject>(boxPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = boxBottomY + (boxSpacingY * i);
            tBoxGO.transform.position = pos;
            boxList.Add(tBoxGO);
        }
    }

    public void RainCollected()
    {
        // Destroy all of the falling Apples
        GameObject[] rainArray = GameObject.FindGameObjectsWithTag("Rain");
        foreach (GameObject tempGO in rainArray)
        {
            Destroy(tempGO);
        }

        // Destroy one of the Baskets                                    // f
        // Get the index of the last Basket in basketList
        int boxIndex = boxList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject boxGO = boxList[boxIndex];
        // Remove the Basket from the list and destroy the GameObject
        boxList.RemoveAt(boxIndex);
        Destroy(boxGO);

        // If there are no Baskets left, restart the game 
        if (boxList.Count == 0)
        {
            SceneManager.LoadScene("Prototype 1");                       // g
        }
    }
}
