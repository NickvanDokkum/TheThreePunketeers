using UnityEngine;
using System.Collections;

public class Piston : MonoBehaviour {

    public GameObject[] colliders;
	public int time = 0;
	AudioSource audioSource;
    
	void Start() {
		audioSource = GetComponent<AudioSource> ();
        InvokeRepeating("CheckTime", 0, 0.5f);
    }
    void ChangeCollider(int collider) {
        for (int i = 0; i < colliders.Length; i++) {
            if (i == collider) {
                colliders[i].SetActive(true);
            }
            else {
                colliders[i].SetActive(false);
            }
        }
    }
    void CheckTime() {
        time++;
        if (time == 1 || time == 6) {
            ChangeCollider(1);
			audioSource.Play();
        }
        else if (time == 2) {
            ChangeCollider(2);
        }
        else if(time == 7){
            ChangeCollider(0);
        }
        else if (time == 11) {
            time = 0;
        }
    }
}
