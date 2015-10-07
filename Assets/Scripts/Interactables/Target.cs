using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    IInteractable interactable;
    public GameObject interactableObject;

    void Awake() {
        interactable = interactableObject.GetComponent<IInteractable>();
        interactableObject = null;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PlayerAttack") {
            interactable.StartThing();
            Destroy(this.gameObject);
        }
    }
}
