using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    // menus
    public Canvas startMenu;
    public Canvas quitMenu;
    public Canvas optionsMenu;
    public Canvas helpMenu;

    // buttons
    public Button playBtn;
    public Button exitBtn;
    public Button optionsBtn;
    public Button helpBtn;
    public Button backBtnOptions;
    public Button backBtnHelp;

    // Use this for initialization
    void Start()
    {
        // assign variables to game objects
        startMenu = startMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();
        optionsMenu = optionsMenu.GetComponent<Canvas>();
        helpMenu = helpMenu.GetComponent<Canvas>();

        playBtn = playBtn.GetComponent<Button>();
        exitBtn = exitBtn.GetComponent<Button>();
        optionsBtn = optionsBtn.GetComponent<Button>();
        helpBtn = helpBtn.GetComponent<Button>();
        backBtnOptions = backBtnOptions.GetComponent<Button>();
        backBtnHelp = backBtnHelp.GetComponent<Button>();

        // instantiate non-start menus to false
        startMenu.enabled = true;
        optionsMenu.enabled = false;
        quitMenu.enabled = false;
        helpMenu.enabled = false;
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

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Play");
    }

    // Show the options by hiding other elements
    public void OptionsButtonPressed()
    {
        // only disable the start menu since only point of access
        startMenu.enabled = false;
        optionsMenu.enabled = true;
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

    // Exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

}
