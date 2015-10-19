using UnityEngine;
using System.Collections;

public class Knockback : MonoBehaviour, IAttack {

    public double cooldown;
    bool canAttack = true;
    public BoxCollider2D colliderRight;
    public BoxCollider2D colliderLeft;
    Movement movement;
    PlayAnimation[] animations;

    void Start() {
        movement = GetComponentInParent<Movement>();
        animations = GetComponents<PlayAnimation>();
    }

    public void StartAttack() {
        if (canAttack && gameObject.activeInHierarchy) {
            canAttack = false;
            Invoke("ResetCooldown", (float)cooldown);
            if (movement.right) {
                colliderRight.enabled = true;
                animations[animations.Length - 3].StartAnimation();
            }
            else {
                colliderLeft.enabled = true;
                animations[animations.Length - 2].StartAnimation();
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
