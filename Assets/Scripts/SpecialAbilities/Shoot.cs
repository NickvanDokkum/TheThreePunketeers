using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour, ISpecial {

    public double cooldown;
    bool canShoot = true;
    public GameObject bullet;
    public Transform spawnpointRight;
    public Transform spawnpointLeft;
    Movement movement;

    void Start() {
        movement = GetComponentInParent<Movement>();
    }

    public void StartSpecial() {
        if (canShoot && gameObject.activeInHierarchy) {
            Debug.Log("BANG");
            canShoot = false;
            Invoke("ResetCooldown", (float)cooldown);
            bullet.GetComponent<Bullet>().right = movement.right;
            if (movement.right) {
                Instantiate(bullet, spawnpointRight.position, spawnpointRight.rotation);
            }
            else {
                Instantiate(bullet, spawnpointLeft.position, spawnpointLeft.rotation);
            }
        }
    }
    void ResetCooldown() {
        canShoot = true;
    }
}
