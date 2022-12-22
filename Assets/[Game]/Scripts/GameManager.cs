using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject gameOver;

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
    
        playButton.SetActive(false);
        gameOver.SetActive(false);
        
        Time.timeScale = 1;
        player.enabled = true;

        PipeMovementHandler[] pipes = FindObjectsOfType<PipeMovementHandler>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    private void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }
    public void GameOver()
    {
       gameOver.SetActive(true);
       playButton.SetActive(true);
       Pause();
       score = 0;
    }
}
