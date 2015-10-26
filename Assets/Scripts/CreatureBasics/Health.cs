using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int maxHealth;
    int curHealth;
    CharacterSwap characterSwap;
	public GameObject enemyDeathSound;

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
			Instantiate(enemyDeathSound, transform.position, transform.rotation);
			Destroy(gameObject);
        }
        else {
            characterSwap.DisableCharacter(gameObject.name, 30);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PlayerAttack" && gameObject.tag == "Enemy") {
            Damage(1);
        }
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Player") {
            Damage(1);
        }
        if (other.gameObject.tag == "InstaDeath") {
            if (gameObject.tag == "Player") {
                Application.LoadLevel(Application.loadedLevel);
            }
            else {
                Damage(999999);
            }
        }
    }
}
