using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float currentMovement;
    public double movementSpeed;
    Rigidbody2D theRigidbody;
    public double jumpForce;
    bool isJumping = false;
    public bool right;
    bool freeze = false;

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
        if (!freeze) {
            transform.Translate(new Vector2(currentMovement * (float)movementSpeed, 0));
        }
	}
    public void Jump() {
        if (!isJumping && !freeze) {
            theRigidbody.AddForce(new Vector2(0, (float)jumpForce * 100));
            isJumping = true;
        }
    }
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Ground") {
            isJumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Ground") {
            isJumping = true;
        }
    }
    public void Freeze(float time) {
        freeze = true;
        CancelInvoke("Move");
        Invoke("Move", time);
    }
    void Move() {
        freeze = false;
    }
    public void ChangeStats(float jumpStrength, float moveSpeed) {
        jumpForce = jumpStrength;
        movementSpeed = moveSpeed;
    }
}
