using UnityEngine;
using System.Collections;

public class RopeSwing : MonoBehaviour, ISpecial {

    Rigidbody2D rigidbodyparent;
    GameObject swingable;
    Movement movement;
    Vector2 difference;
    Vector2 move;
    int times;
    int counter = 0;

    void Awake() {
        movement = GetComponentInParent<Movement>();
        rigidbodyparent = GetComponentInParent<Rigidbody2D>();
    }
    public void StartSpecial() {
        if (swingable != null && gameObject.activeInHierarchy) {
            transform.parent.position = new Vector2(swingable.transform.position.x, swingable.transform.position.y);
            difference = swingable.GetComponent<Rope>().difference();
            move = difference.normalized;
            times = Mathf.CeilToInt(difference.x / move.x);
            Debug.Log(difference + " " + move + " " + times);
            rigidbodyparent.constraints = RigidbodyConstraints2D.FreezeAll;
            InvokeRepeating("MoveFurther", 0.05f, 0.05f);
            movement.Freeze(0.05f * times);
        }
    }
    void MoveFurther() {
        transform.parent.Translate(move);
        counter++;
        if (counter >= times) {
            
            rigidbodyparent.constraints = RigidbodyConstraints2D.None;
            rigidbodyparent.constraints = RigidbodyConstraints2D.FreezeRotation;
            CancelInvoke("MoveFurther");
            movement.Freeze(0);
            counter = 0;
            if (move.x > 0) {
                rigidbodyparent.AddForce(new Vector2(500, 0));
            }
            else {
                rigidbodyparent.AddForce(new Vector2(-500, 0));
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Swingable") {
            swingable = other.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Swingable") {
            swingable = null;
        }
    }
}
