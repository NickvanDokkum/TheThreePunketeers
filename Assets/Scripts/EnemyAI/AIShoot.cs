using UnityEngine;
using System.Collections;

public class AIShoot : MonoBehaviour {

    void Start() {
        InvokeRepeating("shoot", 1, 1);
    }
    void Shoot() {

    }
}
