using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject startScreen;
    [SerializeField] private AudioClip soundFX;


    void Start()
    {
        Time.timeScale = 0; // Freeze the game
        startScreen.SetActive(true);
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore += 1;
        scoreText.text = playerScore.ToString();
        soundFXManager.instance.playSoundFXClip(soundFX, transform);
    }

    public void startGame()
    {
        Time.timeScale = 1; // Un-Freeze the game
        startScreen.SetActive(false);

        playerScore = 0;
        scoreText.text = playerScore.ToString();

    }

    public void restartGame()
    {
        Time.timeScale = 1; // Un-Freeze the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        playerScore = 0;
        scoreText.text = playerScore.ToString();

    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
