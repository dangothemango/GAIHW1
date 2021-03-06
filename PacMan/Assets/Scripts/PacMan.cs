﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMan : Agent {

    float deathTime = 1f;

	// Use this for initialization
	void Start () {
        protStart();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            SetDirection(0);
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            SetDirection(1);
        } else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            SetDirection(2);
        } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            SetDirection(3);
        }
	}

    public void Die() {
        Stop();
        GameManager.INSTANCE.StopAgents();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut() {
        float t = 0;
        Vector3 origScale = transform.localScale;
        while (t<deathTime) {
            t += Time.deltaTime;
            transform.localScale = origScale * (1f - t / deathTime);
            yield return null;
        }
        GameManager.INSTANCE.OnDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.GetComponent<Pellet>() != null) {
            Destroy(collision.gameObject);
            GameManager.INSTANCE.incScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name.Contains("Wall")) {
            rigidBody.velocity = Directions[dir] * speed;
        }
    }
}
