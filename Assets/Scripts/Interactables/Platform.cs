using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour, IInteractable {

    public float speed = 1;
    bool controlled = false;

    public void StartThing() {
        controlled = true;
        GameObject.Find("Nickolas").transform.parent.GetComponent<Movement>().Freeze(9999999);
    }
    void Update() {
        if (controlled) {
            if (Input.GetAxis("Jump") > 0) {
                gameObject.transform.Translate(new Vector2(0, 1 * speed));
            }
            else if (Input.GetAxis("Jump") < 0) {
                gameObject.transform.Translate(new Vector2(0, -1 * speed));
            }
            if (Input.GetButtonDown("Movement") || Input.GetButtonDown("Swap")) {
                GameObject.Find("Nickolas").transform.parent.GetComponent<Movement>().Freeze(0);
                controlled = false;
            }
        }
    }
}
