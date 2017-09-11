using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager INSTANCE;
    public GameObject[] ghosts = { };
    public Text scoreText;
    public Text highScoreText;
    int score = 0;


	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("High_Score")) {
            highScoreText.text = string.Format("High Score: {0}  ", PlayerPrefs.GetInt("High_Score"));
        }
		if (INSTANCE != null) {
            this.enabled = false;
            return;
        }
        INSTANCE = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StopGhosts() {
        foreach (GameObject g in ghosts) {
            g.GetComponent<Ghost>().Stop();
        }
    }

    public void ProcessGameOver() {
        if (!PlayerPrefs.HasKey("High_Score") || score > PlayerPrefs.GetInt("High_Score")) {
            PlayerPrefs.SetInt("High_Score", score);
            highScoreText.text = string.Format("High Score: {0}  ", score);
        } else {
            Debug.Log(PlayerPrefs.GetInt("High_Score"));
        }
    }

    public void incScore() {
        scoreText.text = string.Format("  Score: {0}", ++score);
    }

}
