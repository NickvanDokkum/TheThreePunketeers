using UnityEngine;
using System.Collections;

public class RopeSwing : MonoBehaviour, ISpecial {

    Rigidbody2D rigidbodyparent;
    GameObject swingable;
    Movement movement;
    Vector2 difference;
    Vector2 move;
    CharacterSwap characterSwap;
    int times;
    int counter = 0;
	PlayAnimation[] animations;
	AudioSource[] audioSource;
	
	void Awake() {
		audioSource = GetComponents<AudioSource> ();
		movement = GetComponentInParent<Movement>();
        rigidbodyparent = GetComponentInParent<Rigidbody2D>();
        characterSwap = GetComponentInParent<CharacterSwap>();
        animations = GetComponents<PlayAnimation>();
    }
    public void StartSpecial() {
        if (swingable != null && gameObject.activeInHierarchy) {
			transform.parent.position = new Vector3(swingable.transform.position.x, swingable.transform.position.y, transform.parent.position.z);
            difference = swingable.GetComponent<Rope>().difference();
            move = difference.normalized;
            times = Mathf.CeilToInt(difference.x / move.x);
            rigidbodyparent.constraints = RigidbodyConstraints2D.FreezeAll;
            InvokeRepeating("MoveFurther", 0.05f, 0.05f);
            movement.Freeze(0.05f * times);
            characterSwap.Freeze(999999);
            animations[animations.Length - 1].StartAnimation();
        }
    }
    void MoveFurther() {
		if (!audioSource [1].isPlaying) {
			audioSource[1].Play();
		}
        transform.parent.Translate(move);
        counter++;
        if (counter >= times) {
            characterSwap.Freeze(0);
            rigidbodyparent.constraints = RigidbodyConstraints2D.None;
            rigidbodyparent.constraints = RigidbodyConstraints2D.FreezeRotation;
            CancelInvoke("MoveFurther");
            movement.Freeze(0);
            counter = 0;
            if (move.x > 0) {
                rigidbodyparent.AddForce(new Vector2(500, 0));
            }
            else {
                rigidbodyparent.AddForce(new Vector2(-500, 0));
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Swingable") {
            swingable = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Swingable") {
            swingable = null;
        }
    }
}
