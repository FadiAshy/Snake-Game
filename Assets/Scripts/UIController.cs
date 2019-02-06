using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    /*
     *  This Script is about the UI in the project 
     *  Showing and changing the score and displaying the GameOver Text
     * 
     * */


    public Text Score;
    public Text GameOverText;
    int score;

	void Start () {
        score = 0;
        Score.text = "Score\n[" + score + "]";
	}

    public void AddScore(int S)
    {
        score += S;
        Score.text = "Score\n[" + score + "]";
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
    }

    public void Reset()
    {
        GameOverText.gameObject.SetActive(false);
        score = 0;
        Score.text = "Score\n[" + score + "]";
    }
}
