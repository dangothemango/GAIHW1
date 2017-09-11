using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager INSTANCE;
    //PacMan will always be agents[0]
    public Agent[] agents = { };
    public Image[] LivesUI;
    public Text scoreText;
    public Text highScoreText;
    int livesRemaining;
    int score = 0;


	// Use this for initialization
	void Start () {
        livesRemaining = LivesUI.Length;
        if (PlayerPrefs.HasKey("High_Score")) {
            highScoreText.text = string.Format("{0}", PlayerPrefs.GetInt("High_Score").ToString().PadLeft(5,'0'));
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

    public void StopAgents() {
        foreach (Agent a in agents) {
            a.Stop();
        }
    }

    public void OnDeath() {
        LivesUI[--livesRemaining].gameObject.SetActive(false);
        if (livesRemaining == 0) {
            ProcessGameOver();
        } else {
            foreach (Agent a in agents) {
                a.Reset();
            }
        }
    }

    public void ProcessGameOver() {
        if (!PlayerPrefs.HasKey("High_Score") || score > PlayerPrefs.GetInt("High_Score")) {
            PlayerPrefs.SetInt("High_Score", score);
            highScoreText.text = string.Format("{0}", score.ToString().PadLeft(5, '0'));
        } else {
            Debug.Log(PlayerPrefs.GetInt("High_Score"));
        }
    }

    public void incScore() {
        scoreText.text = string.Format("{0}", (++score).ToString().PadLeft(5, '0'));
    }

}
