// handles pause menu aspects

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseScript : MonoBehaviour {

    // variable declarations
    public Canvas pauseSubMenu;
    public Button mainMenuBtn;
    private bool isPaused;

	// Use this for initialization
	void Start () {
        pauseSubMenu = pauseSubMenu.GetComponent<Canvas>();
        mainMenuBtn = mainMenuBtn.GetComponent<Button>();
        pauseSubMenu.enabled = false;
        isPaused = false;
	}

    // Update is called once per frame
    void Update() {
        if (isPaused)
            PauseGame(true);
        else
            PauseGame(false);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SwitchPause();
        }
	}

    // Alter the timescale value and display/hide menu
    void PauseGame(bool state)
    {
        if (state)
            Time.timeScale = 0.0f; // Pause
        else
            Time.timeScale = 1.0f; // Unpause
        pauseSubMenu.enabled = state;
    }

    // Toggle the pause value
    public void SwitchPause()
    {
        if (isPaused)
            isPaused = false;
        else
            isPaused = true;
    }

    // Load the main menu
    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
