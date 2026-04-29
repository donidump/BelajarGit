using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;
    public GameObject pauseUI;
    public PlayerController playerScript;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SetPlayState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
            {
                PauseGame();
            }
            else if (currentState == GameState.Paused)
            {
                ResumeGame();
            }
        }

        HandlePlayerState();
    }

    void HandlePlayerState()
    {
        if (playerScript == null) return;

        if (currentState == GameState.Paused)
        {
            playerScript.enabled = false;
        }
        else
        {
            playerScript.enabled = true;
        }
    }

    public void PauseGame()
    {
        currentState = GameState.Paused;
        Time.timeScale = 0f;

        if (pauseUI != null)
            pauseUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        SetPlayState();

        if (pauseUI != null)
            pauseUI.SetActive(false);
    }

    void SetPlayState()
    {
        currentState = GameState.Playing;
        Time.timeScale = 1f;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        currentState = GameState.Playing;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        currentState = GameState.MainMenu;
        SceneManager.LoadScene("MainMenu");
    }
}