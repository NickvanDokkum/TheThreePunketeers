using UnityEngine;
using System.Collections;

public class AIShoot : MonoBehaviour {

    public Transform spawnPos;
    public GameObject Projectile;
    public float attackSpeed;

    void Start() {
        InvokeRepeating("Shoot", attackSpeed, attackSpeed);
    }
    void Shoot() {
        Instantiate(Projectile, spawnPos.position, spawnPos.rotation);
    }
}
