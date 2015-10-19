using UnityEngine;
using System.Collections;

public class Rize : MonoBehaviour, IInteractable {

    int counter;

    public void StartThing() {
        InvokeRepeating("GoUp", 0.05f, 0.05f);
    }
    void GoUp() {
        transform.Translate(new Vector2(0, 0.25f));
        counter++;
        if (counter >= 40) {
            Destroy(this);
        }
    }
}
