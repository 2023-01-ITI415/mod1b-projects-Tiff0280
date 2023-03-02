using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     // We need this line for uGUI to work.

public class HighestScore : MonoBehaviour
{
    static private Text _UI_TEXT;                                   
    static private int _SCORE = 1000;                              

    private Text txtCom;  // txtCom is a reference to this GO’s Text component

    void Awake()
    {
        _UI_TEXT = this.GetComponent<Text>();

        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighestScore"))
        {                                        // a
            THESCORE = PlayerPrefs.GetInt("HighestScore");
        }
        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighestScore", THESCORE);                                       // b
    }

     static public int THESCORE
    {
        get { return _SCORE; }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighestScore", value);                                   // c
            if (_UI_TEXT != null)
            {
                _UI_TEXT.text = "Highest Score: " + value.ToString("#,0");
            }
        }
     }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if (scoreToTry <= THESCORE) return; // If scoreToTry is too low, return
        THESCORE = scoreToTry;
    }

    // The following code allows you to easily reset the PlayerPrefs HighScore
    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;                                           // d

    void OnDrawGizmos()
    {                                                            // e
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighestScore", 1000);
            Debug.LogWarning("PlayerPrefs HighestScore reset to 1,000.");
        }
    }
}
