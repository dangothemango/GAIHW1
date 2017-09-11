using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager INSTANCE;
    public GameObject[] ghosts = { };

	// Use this for initialization
	void Start () {
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

    }

}
