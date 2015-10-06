using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("hit");
        if (other.gameObject.tag == "Player") {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
