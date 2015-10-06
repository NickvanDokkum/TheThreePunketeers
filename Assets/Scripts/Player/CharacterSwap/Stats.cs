using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public double jumpStrength;
    public double speed;
    Movement movement;

    void Awake() {
        movement = GetComponentInParent<Movement>();
    }
    void Start() {
        if (gameObject.activeInHierarchy) {
            movement.ChangeStats(jumpingStrength(), walkSpeed());
        }
    }
    public float jumpingStrength() {
        return ((float)jumpStrength);
    }
    public float walkSpeed() {
        return ((float)speed);
    }
    void OnEnable() {
        movement.ChangeStats(jumpingStrength(), walkSpeed());
    }
}
