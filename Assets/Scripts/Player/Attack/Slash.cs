using UnityEngine;
using System.Collections;

public class Slash : MonoBehaviour, IAttack {

    public double cooldown;
    bool canSlash = true;
    public BoxCollider2D colliderRight;
    public BoxCollider2D colliderLeft;
    Movement movement;

    void Start() {
        movement = GetComponentInParent<Movement>();
    }

    public void StartAttack() {
        if (canSlash && gameObject.activeInHierarchy) {
            Debug.Log("Slash");
            canSlash = false;
            Invoke("ResetCooldown", (float)cooldown);
            if (movement.right) {
                colliderRight.enabled = true;
            }
            else {
                colliderLeft.enabled = true;
            }
            Invoke("DisableCollider", 0.1f);
        }
    }
    void DisableCollider() {
        colliderRight.enabled = false;
        colliderLeft.enabled = false;
    }
    void ResetCooldown() {
        canSlash = true;
    }
}
