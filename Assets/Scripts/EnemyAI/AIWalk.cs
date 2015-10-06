using UnityEngine;
using System.Collections;

public class AIWalk : MonoBehaviour {

    bool walkRight = false;
    Movement movement;
    bool ready = true;

    void Awake() {
        movement = GetComponent<Movement>();
    }
    void Start() {
        if (Random.Range(0, 2) == 0) {
            walkRight = true;
        }
        ChangeMovement();
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (ready && other.gameObject.tag == "Edge") {
            ChangeMovement();
            ready = false;
            Invoke("Cooldown", 0.2f);
        }
    }
    void ChangeMovement() {
        if (!walkRight) {
            walkRight = true;
            movement.ChangeMovement(1);
        }
        else {
            walkRight = false;
            movement.ChangeMovement(-1);
        }
    }
    void Cooldown() {
        ready = true;
    }
}
