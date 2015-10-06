using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("hit");
        if (other.gameObject.tag == "Player") {
            if (Application.loadedLevel < Application.levelCount) {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
            else {
                Application.LoadLevel(0);
            }
        }
    }
}
