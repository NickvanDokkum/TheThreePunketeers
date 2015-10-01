using UnityEngine;
using System.Collections;

public class Slash : MonoBehaviour, ISpecial {

    public double cooldown;
    bool canSlash = true;

    public void StartSpecial() {
        if (canSlash && gameObject.activeInHierarchy) {
            Debug.Log("Slash");
            canSlash = false;
            Invoke("ResetCooldown", (float)cooldown);
        }
    }
    void ResetCooldown() {
        canSlash = true;
    }
}
