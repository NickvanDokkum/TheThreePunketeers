using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Sprite[] sprites;
    Image image;
    int health;
    Health healthScript;

    void Awake() {
        healthScript = GameObject.Find(gameObject.name).GetComponent<Health>();
        image = GetComponent<Image>();
    }
    void LateUpdate() {
        int currentHP = healthScript.currentHealth();
        if (health != currentHP) {
            health = currentHP;
            image.sprite = sprites[health];
        }
    }
}
