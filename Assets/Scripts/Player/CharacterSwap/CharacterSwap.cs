using UnityEngine;
using System.Collections;

public class CharacterSwap : MonoBehaviour {

    public GameObject[] playerCharacters;
    int selectedCharacter;
    bool freeze = false;

	void Awake () {
        selectedCharacter = Random.Range(0, 3);
	}
    void Start() {
        ChangeCharacter(selectedCharacter);
    }
    public void ChangeCharacter(int selectCharacter) {
        if (!freeze) {
            selectedCharacter = selectCharacter;
            for (int i = 0; i < playerCharacters.Length; i++) {
                if (i != selectedCharacter) {
                    playerCharacters[i].SetActive(false);
                }
                else {
                    playerCharacters[i].SetActive(true);
                }
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
}
