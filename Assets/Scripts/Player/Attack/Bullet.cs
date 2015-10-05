using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public bool right;
    float speed = 1;
    Vector2 vector;

    void Start() {
        if (right) {
            vector = new Vector2(1 * speed, 0);
        }
        else {
            vector = new Vector2(-1 * speed, 0);
        }
        Invoke("Destruction", 2);
    }
    void Update() {
        transform.Translate(vector);
    }
    void OnCollisionEnter2D(Collision2D other) {
        Destruction();
    }
    void Destruction() {
        Destroy(gameObject);
    }
}
