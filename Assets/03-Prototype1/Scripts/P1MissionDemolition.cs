using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;                                                           

public enum GameMode1
{                                                            
    idle, 
    playing,
    levelEnd
}

public class P1MissionDemolition : MonoBehaviour
{
    static private P1MissionDemolition S; // a private Singleton                
    [Header("Inscribed")]
    public Text uitLevel;  // The UIText_Level Text
    public Text uitShots;  // The UIText_Shots Text
    public Vector3 castlePos; // The place to put castles
    public GameObject[] castles;   // An array of the castles

    [Header("Dynamic")]
    public int level;     // The current level
    public int levelMax;  // The number of levels
    public int shotsTaken;
    public GameObject castle;    // The current castle
    public GameMode1 mode = GameMode1.idle;
    public string showing = "Show Slingshot"; // FollowCam mode

    void Start()
    {
        S = this; // Define the Singleton                                  
    
        level = 0;
        shotsTaken = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    void StartLevel()
    {
        // Get rid of the old castle if one exists
        if (castle != null)
        {
            Destroy(castle);
        }

        // Destroy old projectiles if they exist (the method is not yet written)
        Projectile.DESTROY_PROJECTILES(); // This will be underlined in red  // d

        // Instantiate the new castle
        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;

        // Reset the goal
        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode1.playing;
    }

    void UpdateGUI()
    {
        // Show the data in the GUITexts
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }

    void Update()
    {
        UpdateGUI();

        // Check for level end
        if ((mode == GameMode1.playing) && Goal.goalMet)
        {
            // Change mode to stop checking for level end
            mode = GameMode1.levelEnd;

            // Start the next level in 2 seconds
            Invoke("NextLevel", 2f);                                        
        }
    }
 
    void NextLevel()
    {                                                       
        level++;
        if (level == levelMax)
        {
            level = 0;
            shotsTaken = 0;
        }
        StartLevel();
    }

    // Static method that allows code anywhere to increment shotsTaken
    static public void SHOT_FIRED()
    {                                      
        S.shotsTaken++;
    }
    
    // Static method that allows code anywhere to get a reference to S.castle
    static public GameObject GET_CASTLE()
    {                                  
        return S.castle;
    }
}