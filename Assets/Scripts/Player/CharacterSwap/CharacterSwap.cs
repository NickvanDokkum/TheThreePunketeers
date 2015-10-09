using UnityEngine;
using System.Collections;

public class CharacterSwap : MonoBehaviour {

    public GameObject[] playerCharacters;
    int selectedCharacter;
    bool freeze = false;
    bool disableZero = false;
    bool disableOne = false;
    bool disableTwo = false;
    int antiLoop = 0;

    void Start() {
        selectedCharacter = Random.Range(0, 3);
        ChangeCharacter(selectedCharacter);
        NextCharacter();
    }
    public void ChangeCharacter(int selectCharacter) {
        if (!freeze) {
            selectedCharacter = selectCharacter;
            bool continueing = true;
            if (selectedCharacter == 0) {
                if (disableZero) {
                    continueing = false;
                }
            }
            else if (selectedCharacter == 1) {
                if (disableOne) {
                    continueing = false;
                }
            }
            else if (selectedCharacter == 2) {
                if (disableTwo) {
                    continueing = false;
                }
            }
            if(continueing) {
                antiLoop = 0;
                for (int i = 0; i < playerCharacters.Length; i++) {
                    if (i != selectedCharacter) {
                        playerCharacters[i].SetActive(false);
                    }
                    else {
                        playerCharacters[i].SetActive(true);
                    }
                }
            }
            else {
                antiLoop++;
                if (antiLoop >= 3) {
                    Application.LoadLevel(Application.loadedLevel);
                }
                NextCharacter();
            }
        }
    }
    public void NextCharacter() {
        if (!freeze) {
            if (selectedCharacter < playerCharacters.Length - 1) {
                selectedCharacter++;
            }
            else {
                selectedCharacter = 0;
            }
            ChangeCharacter(selectedCharacter);
        }
    }
    public void Freeze(float time) {
        freeze = true;
        CancelInvoke("UnFreeze");
        Invoke("UnFreeze", time);
    }
    void UnFreeze() {
        freeze = false;
    }
    public void DisableCharacter(string character, int timer) {
        if(character == "Wilson") {
            disableZero = true;
            Invoke("ResetZero", timer);
        }
        else if (character == "Victoria") {
            disableOne = true;
            Invoke("ResetOne", timer);
        }
        else if (character == "Nickolas") {
            disableTwo = true;
            Invoke("ResetTwo", timer);
        }
        if (disableZero && disableOne && disableTwo) {
            Application.LoadLevel(Application.loadedLevel);
        }
        NextCharacter();
    }
    void ResetZero() {
        disableZero = false;
    }
    void ResetOne() {
        disableOne = false;
    }
    void ResetTwo() {
        disableTwo = false;
    }
}
