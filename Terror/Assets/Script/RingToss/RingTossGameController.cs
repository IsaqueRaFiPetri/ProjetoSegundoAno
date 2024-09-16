using UnityEngine;
using TMPro;

public class RingTossGameController : MonoBehaviour
{
    public static RingTossGameController Instance;     // Singleton instance of GameManager
    public int currentScore = 0;                       // Player's score
    public int targetScore = 2;                        // How many rings to win
    public TextMeshProUGUI scoreText;                  // UI Text to show score
    public GameObject winMessage;                      // UI or object to show when player wins

    private void Awake()
    {
        // Ensure only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
        winMessage.SetActive(false); // Hide the win message initially
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateScoreUI();

        if (currentScore >= targetScore)
        {
            WinGame();
        }
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore;
    }

    private void WinGame()
    {
        winMessage.SetActive(true); // Show win message
        Debug.Log("You win!");
    }

    public void ResetGame()
    {
        currentScore = 0;
        UpdateScoreUI();
        winMessage.SetActive(false);
        // Optionally reset rings here
    }
}
