using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float currentMovement;
    public double movementSpeed;
    Rigidbody2D theRigidbody;
    public double jumpForce;
    bool jumping = false;

    void Awake() {
        theRigidbody = GetComponent<Rigidbody2D>();
    }

	public void ChangeMovement(float movement) {
        currentMovement = movement;
	}
	void FixedUpdate () {
        transform.Translate(new Vector2(currentMovement * (float)movementSpeed, 0));
	}
    public void Jump() {
        if (!jumping) {
            jumping = true;
            theRigidbody.AddForce(new Vector2(0, (float)jumpForce * 100));
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            jumping = false;
        }
    }
}
