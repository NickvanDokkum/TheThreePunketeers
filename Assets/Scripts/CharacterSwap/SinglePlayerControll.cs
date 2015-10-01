using UnityEngine;
using System.Collections;

public class SinglePlayerControll : MonoBehaviour {

    CharacterSwap characterSwapScript;
    Movement movementScript;
    ISpecial[] special;

    void Awake() {
        characterSwapScript = GetComponent<CharacterSwap>();
        movementScript = GetComponent<Movement>();
        special = GetComponentsInChildren<ISpecial>();
    }
    void Update() {
        if (Input.GetButtonDown("Swap")) {
            characterSwapScript.NextCharacter();
        }
        if (Input.GetAxis("Movement") != 0) {
            movementScript.ChangeMovement(Input.GetAxis("Movement"));
        }
        else {
            movementScript.ChangeMovement(0);
        }
        if (Input.GetButtonDown("Jump")) {
            movementScript.Jump();
        }
        if (Input.GetButtonDown("Special")) {
            Debug.Log("Special");
            for (int i = 0; i < special.Length; i++) {
                special[i].StartSpecial();
            }
        }
    }
}