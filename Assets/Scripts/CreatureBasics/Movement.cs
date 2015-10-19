using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float currentMovement;
    public double movementSpeed;
    Rigidbody2D theRigidbody;
    public double jumpForce;
    bool isJumping = false;
    bool jumpCooldown = false;
    public bool right;
    bool freeze = false;
    public PlayAnimation[] animationScripts;
    CharacterSwap characterSwap;
    Idle[] idle;

    void Awake() {
        characterSwap = GetComponent<CharacterSwap>();
        theRigidbody = GetComponent<Rigidbody2D>();
        if (tag == "Player") {
            animationScripts = GetComponentsInChildren<PlayAnimation>();
            idle = GetComponentsInChildren<Idle>();
        }
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
            if (currentMovement * (float)movementSpeed < 0) {
                if (tag == "Player") {
                    if (!isJumping) {
                        if (!animationScripts[characterSwap.selectedCharacter * 7 + 1].IsPlaying()) {
                            animationScripts[characterSwap.selectedCharacter * 7 + 1].StartAnimation();
                        }
                    }
                    else {
                        if (!animationScripts[characterSwap.selectedCharacter * 7 + 3].IsPlaying()) {
                            animationScripts[characterSwap.selectedCharacter * 7 + 3].StartAnimation();
                        }
                    }
                }
                else {
                    if (!animationScripts[1].IsPlaying()) {
                        animationScripts[1].StartAnimation();
                    }
                }
            }
            else if (currentMovement * (float)movementSpeed > 0) {
                if (tag == "Player") {
                    if (!isJumping) {
                        if (!animationScripts[characterSwap.selectedCharacter * 7].IsPlaying()) {
                            animationScripts[characterSwap.selectedCharacter * 7].StartAnimation();
                        }
                    }
                    else {
                        if (!animationScripts[characterSwap.selectedCharacter * 7 + 2].IsPlaying()) {
                            animationScripts[characterSwap.selectedCharacter * 7 + 2].StartAnimation();
                        }
                    }
                }
                else {
                    if (!animationScripts[0].IsPlaying()) {
                        animationScripts[0].StartAnimation();
                    }
                }
            }
            else {
                idle[characterSwap.selectedCharacter].ChangeIdle();
            }
        }
	}
    public void Jump() {
        if (!isJumping && !freeze) {
            theRigidbody.AddForce(new Vector2(0, (float)jumpForce * 100));
            isJumping = true;
            jumpCooldown = true;
            Invoke("JumpCooldownReset", 0.5f);
        }
    }
    void JumpCooldownReset() {
        jumpCooldown = false;
    }
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Ground" && !jumpCooldown) {
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
