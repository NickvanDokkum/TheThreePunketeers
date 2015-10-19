using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            if (Application.loadedLevel < Application.levelCount - 1) {
                PlayerPrefs.SetInt("Level", Application.loadedLevel + 1);
                Application.LoadLevel(Application.loadedLevel + 1);
            }
            else {
                Application.LoadLevel(0);
            }
        }
    }
}
