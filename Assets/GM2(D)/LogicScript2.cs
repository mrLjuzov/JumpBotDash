using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LogicScript2 : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    public TextMeshProUGUI highscoreText;
    private int highscore = 0;
    private bool isGameOver2 = false; // Flag to track if the game is over.
    private bool isGameStarted2 = false; // Flag to track if the game has started.
    private const string HighscoreKey2 = "Highscore2";

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (isGameStarted2 && !isGameOver2)
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
        PlayerPrefs.SetInt(HighscoreKey2, highscore);
        PlayerPrefs.Save();
    }

    private void LoadHighscore()
    {
        highscore = PlayerPrefs.GetInt(HighscoreKey2, 0);
    }

    void Start()
    {
        LoadHighscore(); // Initialize highscore from PlayerPrefs
    }

    // This function will be called when the button is clicked or space is pressed.
    public void restartGame()
    {
        if (isGameOver2)
        {
            // Logic to restart the game.
            // For example, reloading the current scene:
            SceneManager.LoadScene(3);
            isGameOver2 = false; // Reset the game over flag.
            isGameStarted2 = false; // Reset the game started flag.
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space key is pressed.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGameStarted2)
            {
                // If space is pressed and the game is over, call the RestartGame function.
                restartGame();
            }
            else
            {
                // If the game hasn't started yet, set the game as started.
                isGameStarted2 = true;
            }
        }
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void gameOver2()
    {
        gameOverScreen.SetActive(true);
        isGameOver2 = true;

        // Display the highscore when the game is over.
        highscoreText.text = "Highscore: " + highscore.ToString();

        SaveHighscore(); // Save the highscore when the game is over.
    }
}
