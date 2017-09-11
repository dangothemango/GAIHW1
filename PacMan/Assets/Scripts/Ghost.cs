using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Agent {

    public Color color = Color.white;

	// Use this for initialization
	void Start () {
        protStart();
	}

    protected override void protStart() {
        base.protStart();
        SpriteRenderer r = GetComponent<SpriteRenderer>();
        r.color = color;
    }

    public override void Restart() {
        base.Restart();
        SetDirection();
    }
	
	// Update is called once per frame
	void Update () {
		if (rigidBody.velocity == Vector2.zero) {
            SetDirection();
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        PacMan pac = collision.gameObject.GetComponent<PacMan>();
        if (pac != null) {
            pac.Die();
        } else {
            SetDirection();
        }
    }
}
