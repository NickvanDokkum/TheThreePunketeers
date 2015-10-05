using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {

    IInteractable interactable;
    public GameObject interactableObject;
    public bool useOnce;

    void Awake() {
        interactable = interactableObject.GetComponent<IInteractable>();
        interactableObject = null;
    }

    public void StartThing() {
        interactable.StartThing();
        if (useOnce) {
            Destroy(GetComponent<Collider2D>());
            Destroy(this);
        }
    }
}
