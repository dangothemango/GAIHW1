using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    public float speed = .5f;
    protected static Vector2[] Directions = { Vector2.down, Vector2.right, Vector2.up, Vector2.left };
    protected Rigidbody2D rigidBody;
    protected int dir = 0;
    protected Vector3 startPosition;
    protected Vector3 startScale;

    // Use this for initialization
    void Start () {
        protStart();
    }

    protected virtual void protStart() {
        rigidBody = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        startScale = transform.localScale;
        enabled = false;
    }

    protected void SetDirection(int newDir = -1) {
        if (newDir == -1) {
            int t = dir;
            while (t == dir) {
                t = Random.Range(0, 4);
            }
            dir = t;
        }
        else {
            dir = newDir;
        }
        rigidBody.velocity = Directions[dir] * speed;
        transform.rotation = Quaternion.Euler(0, 0, 90 * dir);
    }

    public void Stop() {
        rigidBody.velocity = Vector2.zero;
        enabled = false;
    }

    public virtual void Restart() {
        enabled = true;
        transform.position = startPosition;
        transform.localScale = startScale;
    }
}
