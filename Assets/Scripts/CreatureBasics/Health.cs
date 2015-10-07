using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int curHealth;

    public void Damage(int damage) {
        curHealth -= damage;
        if (curHealth <= 0) {
            Death();
        }
    }
    void Death() {
        Destroy(this.gameObject);
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy" && gameObject.tag == "Player") {
            Damage(1);
        }
        if (other.gameObject.tag == "InstaDeath") {
            Death();
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PlayerAttack" && gameObject.tag == "Enemy") {
            Damage(1);
        }
    }
}
