using UnityEngine;
using System.Collections;

public class SoundQuieter : MonoBehaviour {
	
	AudioSource audioSource;
	SpriteRenderer spriteRenderer;

	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer> ();
		audioSource = GetComponent<AudioSource> ();
		if (!spriteRenderer.isVisible) {
			OnBecameInvisible();
		}
		spriteRenderer = null;
	}
	void OnBecameInvisible() {
		audioSource.volume = 0;
	}
	void OnBecameVisible(){
		audioSource.volume = 1;
	}
}
