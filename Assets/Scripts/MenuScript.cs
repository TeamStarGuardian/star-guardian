using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    // menus
    public Canvas startMenu;
    public Canvas quitMenu;
    public Canvas creditsMenu;
    public Canvas optionsMenu;
    public Canvas helpMenu;

    // buttons
    public Button playBtn;
    public Button exitBtn;
    public Button optionsBtn;
    public Button helpBtn;
    public Button backBtnOptions;
    public Button backBtnHelp;
    public Button musicBtn;
    public Button difficultyBtn;
    public Button closeBtn;
    public Button creditsBtn;

    // music and difficulty
    public AudioSource music;
    private bool musicEnabled;
    private bool isEasy;

    // Use this for initialization
    void Start()
    {
        // assign variables to game objects
        startMenu = startMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        creditsMenu = creditsMenu.GetComponent<Canvas>();
        helpMenu = helpMenu.GetComponent<Canvas>();

        playBtn = playBtn.GetComponent<Button>();
        exitBtn = exitBtn.GetComponent<Button>();
        optionsBtn = optionsBtn.GetComponent<Button>();
        helpBtn = helpBtn.GetComponent<Button>();
        backBtnOptions = backBtnOptions.GetComponent<Button>();
        backBtnHelp = backBtnHelp.GetComponent<Button>();
        musicBtn = musicBtn.GetComponent<Button>();
        difficultyBtn = difficultyBtn.GetComponent<Button>();
        creditsBtn = creditsBtn.GetComponent<Button>();
        closeBtn = closeBtn.GetComponent<Button>();

        music = music.GetComponent<AudioSource>();

        // instantiate non-start menus to false
        startMenu.enabled = true;
        optionsMenu.enabled = false;
        quitMenu.enabled = false;
        helpMenu.enabled = false;
        creditsMenu.enabled = false;

        // set booleans for music and diff
        musicEnabled = GlobalControl.Instance.musicOn;
        isEasy = GlobalControl.Instance.isEasy;

        // update the values and labels accordingly
        if (!musicEnabled) {
            musicBtn.GetComponentInChildren<Text>().text = "turn music on";
            music.enabled = false;
            music.Stop();
        }  
        if (!isEasy) {
            // stuff here to handle level difficulty
            difficultyBtn.GetComponentInChildren<Text>().text = "set difficulty: easy";
        }

        //musicEnabled = true;
        //isEasy = true;
    }

    // Show exit submenu and disable the buttons
    public void ExitButtonPressed()
    {
        quitMenu.enabled = true;
        playBtn.enabled = false;
        exitBtn.enabled = false;
        optionsBtn.enabled = false;
        helpBtn.enabled = false;
    }

    // Hide exit submenu and re-enable the buttons
    public void ExitMenuNoPressed()
    {
        quitMenu.enabled = false;
        playBtn.enabled = true;
        exitBtn.enabled = true;
        helpBtn.enabled = true;
        optionsBtn.enabled = true;
    }

    // Save the state into the GlobalManager and load the play scene
    public void PlayButtonPressed()
    {
        SaveState();
        SceneManager.LoadScene("Play");
    }

    // Show the options by hiding other elements
    public void OptionsButtonPressed()
    {
        // only disable the start menu since only point of access
        startMenu.enabled = false;
        optionsMenu.enabled = true;
    }

    // Display the credits screen, disable other buttons
    public void CreditsButtonPressed()
    {
        creditsMenu.enabled = true;
        backBtnOptions.enabled = false;
        musicBtn.enabled = false;
        difficultyBtn.enabled = false;
    }
    
    // Hide the credits screen, re-enable the other buttons
    public void CloseButtonPressed()
    {
        creditsMenu.enabled = false;
        backBtnOptions.enabled = true;
        musicBtn.enabled = true;
        difficultyBtn.enabled = true;
    }

    // Show the help menu by hiding others
    public void HelpButtonPressed()
    {
        helpMenu.enabled = true;
        startMenu.enabled = false;
    }

    // Universal back button pressed method
    public void BackButtonPressed()
    {
        startMenu.enabled = true;
        helpMenu.enabled = false;
        optionsMenu.enabled = false;
    }

    // Toggle the music
    public void MusicButtonPressed()
    {
        if (musicEnabled)
        {
            musicEnabled = false;
            music.enabled = false;
            music.Stop();
            musicBtn.GetComponentInChildren<Text>().text = "turn music on";
            // toggle comment
        } else if (!musicEnabled)
        {
            musicEnabled = true;
            music.enabled = true;
            music.Play();
            musicBtn.GetComponentInChildren<Text>().text = "turn music off";
        }
    }

    // Toggle the difficulty
    public void DifficultyButtonPressed()
    {
        if (isEasy)
        {
            isEasy = false;
            difficultyBtn.GetComponentInChildren<Text>().text = "set difficulty: easy";
        } else
        {
            isEasy = true;
            difficultyBtn.GetComponentInChildren<Text>().text = "set difficulty: hard";
        }
    }

    // Deals with data persistence between scenes
    public void SaveState()
    {
        GlobalControl.Instance.isEasy = isEasy;
        GlobalControl.Instance.musicOn = musicEnabled;
    }

    // Exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

}
