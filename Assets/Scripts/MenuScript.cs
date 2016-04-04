using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour
{

    public Canvas quitMenu;
    public Button playBtn;
    public Button exitBtn;

    // Use this for initialization
    void Start()
    {
        // assign variables to game objects
        quitMenu = quitMenu.GetComponent<Canvas>();
        playBtn = playBtn.GetComponent<Button>();
        exitBtn = playBtn.GetComponent<Button>();
        quitMenu.enabled = false;
    }

    // Show exit submenu and disable the buttons
    public void ExitButtonPressed()
    {
        quitMenu.enabled = true;
        playBtn.enabled = false;
        exitBtn.enabled = false;
    }

    // Hide exit submenu and re-enable the buttons
    public void ExitMenuNoPressed()
    {
        quitMenu.enabled = false;
        playBtn.enabled = true;
        exitBtn.enabled = true;
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("Play");
        //string sceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    // Exit the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
