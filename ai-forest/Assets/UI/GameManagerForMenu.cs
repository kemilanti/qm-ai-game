using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerForMenu : MonoBehaviour
{
    public GameObject bag;
    public GameObject pauseMenu; 
    public Button resumeButton; // 
    public Button quitButton; // 

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
        // ESC
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
        // open bag
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!isPaused)
            {
                openBag();
            }
            else
            {
                closeBag();
            }
        }
    }
    void openBag()
    {
        isPaused = true;
        bag.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void closeBag()
    {
        isPaused = false;
        bag.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
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