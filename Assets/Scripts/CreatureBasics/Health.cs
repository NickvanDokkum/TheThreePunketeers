using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHealth;
    int curHealth;
    CharacterSwap characterSwap;

    public int currentHealth() {
        return (curHealth);
    }

    void Start() {
        characterSwap = GetComponentInParent<CharacterSwap>();
        curHealth = maxHealth;
    }

    public void Damage(int damage) {
        curHealth -= damage;
        if (curHealth <= 0) {
            Death();
        }
        if (curHealth < maxHealth) {
            if (!IsInvoking("Regen")) {
                Invoke("Regen", 29.5f);
            }
        }
    }
    void Regen() {
        Damage(-1);
    }
    void Death() {
        if (tag != "Player") {
            Destroy(this.gameObject);
        }
        else {
            characterSwap.DisableCharacter(gameObject.name, 30);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        //Debug.Log(other.gameObject.tag + " " + gameObject.tag);
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Player") {
            Damage(1);
        }
        if (other.gameObject.tag == "PlayerAttack" && gameObject.tag == "Enemy") {
            Damage(1);
        }
        if (other.gameObject.tag == "InstaDeath") {
            if (tag == "Player") {
                Application.LoadLevel(Application.loadedLevel);
            }
            else {
                Death();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.gameObject.tag + " " + gameObject.tag);
        if (other.gameObject.tag == "PlayerAttack" && gameObject.tag == "Enemy") {
            Damage(1);
        }
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Player") {
            Damage(1);
        }
    }
}
