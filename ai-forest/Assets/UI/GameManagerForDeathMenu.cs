using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerForDeathMenu : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    private void OnEnable()
    {
        Invoke("EnableCursor", 0.1f);
    }

    private void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnDisable()
    {
        Invoke("DisableCursor", 0.1f);
    }
    private void DisableCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
    }

    void Start()
    {
        // Ensure the death menu is not active when the game starts
        gameObject.SetActive(false);

        // Attach RestartGame method to the restart button's onClick event
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void RestartGame()
    {
        Debug.Log("Restart button clicked"); // This line is for debugging purposes
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        Time.timeScale = 1f; // Ensure the game's time scale is reset before quitting
        SceneManager.LoadScene("MainMenu"); // Loads the main menu scene
    }
}
