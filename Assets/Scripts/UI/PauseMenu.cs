using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    GameObject pauseMenu;

    void Awake() {
        pauseMenu = transform.GetChild(0).gameObject;
        pauseMenu.SetActive(false);
    }
    void Update() {
        if (Input.GetButtonDown("Pause")) {
            if (Time.timeScale != 0) {
                pause();
            }
            else {
                Unpause();
            }
        }
    }
    void pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Unpause() {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void Restart() {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void BackToMenu() {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }
}
