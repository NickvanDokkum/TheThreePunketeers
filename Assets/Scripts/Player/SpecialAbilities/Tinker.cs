using UnityEngine;
using System.Collections;

public class Tinker : MonoBehaviour, ISpecial {

    public double cooldown;
    GameObject hackable;

    public void StartSpecial() {
        if (hackable != null && gameObject.activeInHierarchy) {
            transform.parent.position = new Vector2(hackable.transform.position.x, hackable.transform.position.y);
            hackable.GetComponent<Panel>().StartThing();
            hackable = null;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Hackable") {
            hackable = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Hackable") {
            hackable = null;
        }
    }
}
