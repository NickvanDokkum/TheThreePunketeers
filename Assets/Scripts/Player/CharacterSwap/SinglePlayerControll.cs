using UnityEngine;
using System.Collections;

public class SinglePlayerControll : MonoBehaviour {

    CharacterSwap characterSwapScript;
    Movement movementScript;
    IAttack[] attack;
    ISpecial[] special;

    void Awake() {
        characterSwapScript = GetComponent<CharacterSwap>();
        movementScript = GetComponent<Movement>();
        attack = GetComponentsInChildren<IAttack>();
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
        if (Input.GetAxis("Jump") > 0) {
            movementScript.Jump();
        }
        if (Input.GetButtonDown("Attack")) {
            Debug.Log("Attack");
            for (int i = 0; i < attack.Length; i++) {
                attack[i].StartAttack();
            }
        }
        if (Input.GetButtonDown("Special")) {
            Debug.Log("Special");
            for (int i = 0; i < attack.Length; i++) {
                special[i].StartSpecial();
            }
        }
    }
}