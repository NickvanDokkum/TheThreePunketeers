using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public Transform player;
    public float maxPosLeft;
    public float maxPosRight;

    void LateUpdate() {
        transform.position = new Vector3(player.position.x, transform.position.y, -10);
        if (transform.position.x < maxPosLeft) {
            transform.position = new Vector3(maxPosLeft, transform.position.y, -10);
        }
        else if (transform.position.x > maxPosRight) {
            transform.position = new Vector3(maxPosRight, transform.position.y, -10);
        }
    }
}
