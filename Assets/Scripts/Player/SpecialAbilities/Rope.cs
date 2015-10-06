using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {

    public Transform otherSide;

    public Vector2 difference() {
        return (otherSide.transform.position - transform.position);
    }
}
