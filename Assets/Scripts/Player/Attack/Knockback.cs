using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour, IAttack {

    public double cooldown;
    bool canAttack = true;
    public BoxCollider2D colliderRight;
    public BoxCollider2D colliderLeft;
    Movement movement;

    void Start() {
        movement = GetComponentInParent<Movement>();
    }

    public void StartAttack() {
        if (canAttack && gameObject.activeInHierarchy) {
            canAttack = false;
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
        canAttack = true;
    }
}
