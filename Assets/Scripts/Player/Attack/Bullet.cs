using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public bool right;
    public float speed = 1;
    public float timeDecay = 2;
    Vector2 vector;

    void Start() {
        if (right) {
            vector = new Vector2(1 * speed, 0);
        }
        else {
            vector = new Vector2(-1 * speed, 0);
        }
        Invoke("Destruction", timeDecay);
    }
    void Update() {
        transform.Translate(vector * Time.deltaTime * 60);
    }
    void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag != "Hackable" && other.gameObject.tag != "PlayerAttack") {
			Destruction ();
		}
    }
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag != "Hackable" && other.gameObject.tag != "PlayerAttack") {
			Destruction ();
		}
	}
    void Destruction() {
        Destroy(gameObject);
    }
}
