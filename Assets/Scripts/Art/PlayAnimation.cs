using UnityEngine;
using System.Collections;

public class PlayAnimation : MonoBehaviour {

    public bool startFromBeginning = true;
    public bool playOnce = false;
    public Sprite[] sprites;
    public float cooldown;
    public float playSpeed;
    public int currentFrame = 0;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (cooldown == 0) {
            cooldown = playSpeed;
        }
        if (startFromBeginning) {
            InvokeRepeating("NextFrame", 0, playSpeed);
        }
    }
    public void StartAnimation() {
        gameObject.SendMessage("StopAnimation", SendMessageOptions.DontRequireReceiver);
        InvokeRepeating("NextFrame", 0, playSpeed);
    }
    public bool IsPlaying() {
        return(IsInvoking("NextFrame"));
    }
    public void StopAnimation() {
        CancelInvoke("NextFrame");
    }
    void NextFrame() {
        if (currentFrame < sprites.Length - 1) {
            currentFrame++;
        }
        else {
            currentFrame = 0;
            CancelInvoke("NextFrame");
            InvokeRepeating("NextFrame", cooldown, playSpeed);
        }
        if (!playOnce) {
            spriteRenderer.sprite = sprites[currentFrame];
        }
    }
}
