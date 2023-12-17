using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    private int score;
    public bool isGameActive;
    private float timeLeft = 60f;
    public static GameManagerX instance;
    private int highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        ShowTitleScreen();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    public void ShowTitleScreen()
    {
        isGameActive = false;
        Time.timeScale = 0;
        titleScreen.SetActive(true);
        restartButton.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        Time.timeScale = 1;
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        timeLeft = 60f;
        timeText.SetText("Time: " + Mathf.Round(timeLeft));
        restartButton.gameObject.SetActive(false);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High Score: " + highScore;
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            timeText.SetText("Time: " + Mathf.Round(timeLeft));
            if (timeLeft <= 0)
            {
                GameOver();
            }
        }
    }
}
