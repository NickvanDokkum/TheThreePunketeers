using UnityEngine;
using System.Collections;

public class AIWalk : MonoBehaviour {

    Movement movement;

    void Awake() {
        movement = GetComponent<Movement>();
    }
    void Start() {
        if (Random.Range(0, 2) == 0) {
            movement.ChangeMovement(-1);
        }
        else {
            movement.ChangeMovement(1);
        }
    }
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "EdgeLeft") {
            movement.ChangeMovement(1);
        }
        else if (other.gameObject.tag == "EdgeRight") {
            movement.ChangeMovement(-1);
        }
    }
	void OnColliderStay2D(Collider2D other) {
		if (other.gameObject.tag == "EdgeLeft") {
			movement.ChangeMovement(1);
		}
		else if (other.gameObject.tag == "EdgeRight") {
			movement.ChangeMovement(-1);
		}
	}
}
