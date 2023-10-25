using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerForMenu : MonoBehaviour
{
    public GameObject pauseMenu; // 暂停菜单的Canvas GameObject
    public Button resumeButton; // “继续”按钮
    public Button quitButton; // “退出”按钮

    private bool isPaused = false;

    void Start()
    {
        // 初始化设置
        pauseMenu.SetActive(false);
        resumeButton.onClick.AddListener(ResumeGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        // 监听“ESC”键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void QuitGame()
    {
        // 这里你可以添加任何退出游戏前的逻辑
        SceneManager.LoadScene("MainMenu"); // 加载主菜单场景
    }
}