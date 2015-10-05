using UnityEngine;
using System.Collections;

public class Rize : MonoBehaviour, IInteractable {

    int counter;

    public void StartThing() {
        InvokeRepeating("GoUp", 0.1f, 0.1f);
    }
    void GoUp() {
        transform.Translate(new Vector2(0, 0.5f));
        counter++;
        if (counter >= 20) {
            Destroy(this);
        }
    }
}
