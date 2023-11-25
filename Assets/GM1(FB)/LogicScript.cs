using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public TextMeshProUGUI highscoreText;

    private int highscore = 0;
    private bool isGameOver = false; // Flag to track if the game is over.
    private bool isGameStarted = false; // Flag to track if the game has started.
    private const string HighscoreKey = "Highscore";

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (isGameStarted && !isGameOver)
        {
            playerScore += scoreToAdd;
            scoreText.text = playerScore.ToString();

            if (playerScore > highscore)
            {
                highscore = playerScore;
            }
        }
    }

    private void SaveHighscore()
    {
        PlayerPrefs.SetInt(HighscoreKey, highscore);
        PlayerPrefs.Save();
    }

    private void LoadHighscore()
    {
        highscore = PlayerPrefs.GetInt(HighscoreKey, 0);
    }

    void Start()
    {
        LoadHighscore(); // Initialize highscore from PlayerPrefs
    }

    public void restartGame()
    {
        if (isGameOver)
        {
            // Logic to restart the game.
            // For example, reloading the current scene:
            SceneManager.LoadScene(2);
            isGameOver = false; // Reset the game over flag.
            isGameStarted = false; // Reset the game started flag.
        }
    }

    void Update()
    {
        // Check if the space key is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGameStarted)
            {
                // If space is pressed and the game is over, call the RestartGame function.
                restartGame();
            }
            else
            {
                // If the game hasn't started yet, set the game as started.
                isGameStarted = true;
            }
        }
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;

        // Display the highscore when the game is over.
        highscoreText.text = "Highscore: " + highscore.ToString();

        SaveHighscore(); // Save the highscore when the game is over.
    }

}

