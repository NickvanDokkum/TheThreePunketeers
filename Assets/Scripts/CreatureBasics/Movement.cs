using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float currentMovement;
    public double movementSpeed;
    Rigidbody2D theRigidbody;
    public double jumpForce;
    int groundsTouching = 0;
    public bool right;

    void Awake() {
        theRigidbody = GetComponent<Rigidbody2D>();
    }

	public void ChangeMovement(float movement) {
        currentMovement = movement;
        if (movement > 0) {
            right = true;
        }
        else if(movement < 0){
            right = false;
        }
	}
	void FixedUpdate () {
        transform.Translate(new Vector2(currentMovement * (float)movementSpeed, 0));
	}
    public void Jump() {
        if (groundsTouching > 0) {
            theRigidbody.AddForce(new Vector2(0, (float)jumpForce * 100));
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            groundsTouching++;
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            groundsTouching--;
        }
    }
}
