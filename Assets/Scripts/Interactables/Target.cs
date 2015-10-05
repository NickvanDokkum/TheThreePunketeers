using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    IInteractable interactable;
    public GameObject interactableObject;

    void Awake() {
        interactable = interactableObject.GetComponent<IInteractable>();
        interactableObject = null;
    }

    public void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("hit");
        if (other.gameObject.tag == "PlayerAttack") {
            interactable.StartThing();
            Destroy(this.gameObject);
        }
    }
}
