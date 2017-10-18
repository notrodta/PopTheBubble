using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenScore : MonoBehaviour {

    public TextMeshPro score;
    public TextMeshPro highScore;

    // Use this for initialization
    void Start () {
        score.text = "Score: " + PlayerPrefs.GetInt("score", 0).ToString();
        highScore.text = "HighScore: " + PlayerPrefs.GetInt("highscore", 0).ToString();
    }
	
 
}
