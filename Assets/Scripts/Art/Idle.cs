using UnityEngine;
using System.Collections;

public class Idle : MonoBehaviour {

    public Sprite idleSprite;
    SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeIdle();
    }
    public void ChangeIdle() {
        gameObject.SendMessage("StopAnimation", SendMessageOptions.DontRequireReceiver);
        spriteRenderer.sprite = idleSprite;
    }
}
