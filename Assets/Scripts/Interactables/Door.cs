using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour, IInteractable {

    public Sprite[] sprites;
    int currFrame = 0;
    SpriteRenderer spriteRenderer;
    public float openSpeed = 0.2f;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartThing() {
        InvokeRepeating("NextFrame", 0, openSpeed);
        GameObject.Find("Nickolas").transform.parent.GetComponent<Movement>().Freeze(openSpeed * (sprites.Length - 1));
    }
    void NextFrame() {
        spriteRenderer.sprite = sprites[currFrame];
        currFrame++;
        if (currFrame >= sprites.Length) {
            Destroy(GetComponent<Collider2D>());
            Destroy(this);
        }
    }
}
