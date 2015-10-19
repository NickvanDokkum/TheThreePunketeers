using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

    public Button continueButton;

    void Start() {
        if (PlayerPrefs.GetInt("Level") == 0) {
            continueButton.interactable = false;
        }
    }
    public void Continue() {
        Application.LoadLevel(PlayerPrefs.GetInt("Level"));
    }
    public void NewGame() {
        PlayerPrefs.SetInt("Level", 0);
        Application.LoadLevel(1);
    }
}
