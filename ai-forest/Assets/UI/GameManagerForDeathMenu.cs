using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerForDeathMenu : MonoBehaviour
{
    public GameObject deathUI; // Assume this is your death UI panel
    public Button restartButton;
    public Button quitButton;

    private void OnEnable()
    {
        // 
        GameManagerForMenu.Instance.ShowCursor();
        GameManagerForMenu.Instance.PauseGame();
    }

    private void OnDisable()
    {
        // 
        GameManagerForMenu.Instance.HideCursor();
        GameManagerForMenu.Instance.ResumeGame();
    }

    void Start()
    {
        // Ensure the death menu is not active when the game starts
        deathUI.SetActive(false);

        // Attach RestartGame method to the restart button's onClick event
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure the game's time scale is reset before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the current scene
    }

    void QuitGame()
    {
        Time.timeScale = 1f; // Ensure the game's time scale is reset before quitting
        SceneManager.LoadScene("MainMenu"); // Loads the main menu scene
    }
}
