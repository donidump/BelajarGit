using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.currentState = GameState.Playing;
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        GameManager.Instance.currentState = GameState.Playing;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        GameManager.Instance.currentState = GameState.Paused;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.currentState = GameState.Playing;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        GameManager.Instance.currentState = GameState.MainMenu;
        SceneManager.LoadScene("Menu");
    }
}