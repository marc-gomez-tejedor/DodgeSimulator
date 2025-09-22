using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI scoreTextFinal;  // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI highscoreTextFinal;  // Reference to the TextMeshProUGUI component
    public float scoreMultiplier = 2.0f;  // Multiplier to make the score increase faster
    private float score;  // Stores the current score
    private int highScore;
    public TMP_InputField inputName;
    public UnityEvent<string, int> submitScoreEvent;
    void Start()
    {
        score = 0.0f;  // Initialize the score to 0
        highScore = LoadHighScore();
    }

    void Update()
    {
        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();  // Convert to an integer to display
    }

    public void ShowScore()
    {
        SaveHighScore(Mathf.FloorToInt(score));
        highScore = LoadHighScore();
        scoreTextFinal.text = "Score: " + (Mathf.FloorToInt(score));
        highscoreTextFinal.text = "Personal Record: " + highScore;
    }

    int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    void SaveHighScore(int score)
    {
        if (score > highScore)
        {
            int newscore = Mathf.FloorToInt(score);
            PlayerPrefs.SetInt("HighScore", newscore);
            PlayerPrefs.Save();
        }
    }
    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, Mathf.FloorToInt(score));
    }
}
