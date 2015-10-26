using UnityEngine;
using System.Collections;

public class Tinker : MonoBehaviour, ISpecial {

    public double cooldown;
    GameObject hackable;
	PlayAnimation[] animations;
	AudioSource audioSource;

	void Awake() {
		audioSource = GetComponent<AudioSource> ();
        animations = GetComponents<PlayAnimation>();
    }

    public void StartSpecial() {
        if (hackable != null && gameObject.activeInHierarchy) {
			audioSource.Play();
            transform.parent.position = new Vector3(hackable.transform.position.x, hackable.transform.position.y, transform.parent.position.z);
            hackable.GetComponent<Panel>().StartThing();
            hackable = null;
            animations[animations.Length - 1].StartAnimation();
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Hackable") {
            hackable = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Hackable") {
            hackable = null;
        }
    }
}
