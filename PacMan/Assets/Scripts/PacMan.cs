using System.Collections;
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
        if (Input.GetKeyDown(KeyCode.S)) {
            SetDirection(0);
        } else if (Input.GetKeyDown(KeyCode.D)) {
            SetDirection(1);
        } else if (Input.GetKeyDown(KeyCode.W)) {
            SetDirection(2);
        } else if (Input.GetKeyDown(KeyCode.A)) {
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
}
