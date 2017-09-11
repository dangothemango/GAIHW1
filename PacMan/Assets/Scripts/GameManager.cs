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
    public GameObject startButton;
    int livesRemaining;
    int score;


	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("High_Score")) {
            highScoreText.text = string.Format("{0}", PlayerPrefs.GetInt("High_Score").ToString().PadLeft(5,'0'));
        }
		if (INSTANCE != null) {
            this.enabled = false;
            return;
        }
        INSTANCE = this;
	}

    public void StartGame() {
        score = 0;
        livesRemaining = LivesUI.Length;
        ResetAgents();
        foreach (Image i in LivesUI) {
            i.gameObject.SetActive(true);
        }
        startButton.SetActive(false);
        ResetPellets();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ResetAgents() {
        foreach (Agent a in agents) {
            a.Restart();
        }
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
            ResetAgents();
        }
    }

    public void ProcessGameOver() {
        if (!PlayerPrefs.HasKey("High_Score") || score > PlayerPrefs.GetInt("High_Score")) {
            PlayerPrefs.SetInt("High_Score", score);
            highScoreText.text = string.Format("{0}", score.ToString().PadLeft(5, '0'));
        }
        startButton.GetComponentInChildren<Text>().text = "Restart";
        startButton.SetActive(true);
    }

    public void incScore() {
        scoreText.text = string.Format("{0}", (++score).ToString().PadLeft(5, '0'));
    }

    //use this to put all pellets back after restart
    void ResetPellets() {

    }

}
