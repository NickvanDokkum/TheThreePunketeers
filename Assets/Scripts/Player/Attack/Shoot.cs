using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour, IAttack {

    public double cooldown;
    bool canShoot = true;
    public GameObject bullet;
    public Transform spawnpointRight;
    public Transform spawnpointLeft;
    Movement movement;
    PlayAnimation[] animations;

    void Awake() {
        movement = GetComponentInParent<Movement>();
        animations = GetComponents<PlayAnimation>();
    }

    public void StartAttack() {
        if (canShoot && gameObject.activeInHierarchy) {
            canShoot = false;
            Invoke("ResetCooldown", (float)cooldown);
            bullet.GetComponent<Bullet>().right = movement.right;
            if (movement.right) {
                Instantiate(bullet, spawnpointRight.position, spawnpointRight.rotation);
                animations[animations.Length - 3].StartAnimation();
            }
            else {
                Instantiate(bullet, spawnpointLeft.position, spawnpointLeft.rotation);
                animations[animations.Length - 2].StartAnimation();
            }
        }
    }
    void ResetCooldown() {
        canShoot = true;
    }
}
