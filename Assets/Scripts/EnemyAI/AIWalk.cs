using UnityEngine;
using System.Collections;

public class AIWalk : MonoBehaviour {

    Movement movement;
    bool ready = true;

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
    void OnTriggerEnter2D(Collider2D other) {
        if (ready) {
            if (other.gameObject.tag == "EdgeLeft") {
                movement.ChangeMovement(1);
            }
            else if (other.gameObject.tag == "EdgeRight") {
                movement.ChangeMovement(-1);
            }
            ready = false;
            Invoke("Cooldown", 0.2f);
        }
    }
    void Cooldown() {
        ready = true;
    }
}
