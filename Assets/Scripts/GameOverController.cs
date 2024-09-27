using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenuButton;
    public TMP_Text gameOverText;
    public GameObject gameOverPanel;

    void Start()
    {
        restartButton.onClick.AddListener(GameManager.Instance.StartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        GameManager.Instance.OnGameEnd += ShowGameOverPanel;
        gameOverPanel.SetActive(false);
    }

    void ShowGameOverPanel(float timer)
    {
        gameOverPanel.SetActive(true);
        gameOverText.SetText("Finished \n Time: " + timer.ToString("F2"));
    }

    void ReturnToMainMenu()
    {
        gameOverPanel.SetActive(false);
        GameManager.Instance.ReturnToMainMenu();
    }

    void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnGameEnd -= ShowGameOverPanel;
        }
    }
}