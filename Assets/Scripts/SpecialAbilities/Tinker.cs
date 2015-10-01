using UnityEngine;
using System.Collections;

public class Tinker : MonoBehaviour, ISpecial {

    public double cooldown;
    bool canTinker = true;

    public void StartSpecial() {
        if (canTinker && gameObject.activeInHierarchy) {
            Debug.Log("Tinker Tinker");
            canTinker = false;
            Invoke("ResetCooldown", (float)cooldown);
        }
    }
    void ResetCooldown() {
        canTinker = true;
    }
}
