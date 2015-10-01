using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour, ISpecial {

    public double cooldown;
    bool canShoot = true;

    public void StartSpecial() {
        if (canShoot && gameObject.activeInHierarchy) {
            Debug.Log("BANG");
            canShoot = false;
            Invoke("ResetCooldown", (float)cooldown);
        }
    }
    void ResetCooldown() {
        canShoot = true;
    }
}
