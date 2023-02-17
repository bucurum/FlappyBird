using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    private AudioSource audioSourceScore;
    private AudioSource audioSourceLose;
    private AudioSource audioSourceWing;
    private int score = 0;
    [SerializeField] Player player;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject gameOver;

    public void IncreaseScore()
    {
        audioSourceScore.Play();
        score++;
        scoreText.text = score.ToString();
    }

    void Awake()
    {
        audioSourceScore = GameObject.FindGameObjectWithTag("ScoreSound").GetComponent<AudioSource>();
        audioSourceLose = GameObject.FindGameObjectWithTag("LostSound").GetComponent<AudioSource>();
        audioSourceWing = GameObject.FindGameObjectWithTag("WingSound").GetComponent<AudioSource>();
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
        Pause();
        audioSourceLose.Play();
        gameOver.SetActive(true);
        playButton.SetActive(true);
        score = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //add touch input
        {
            audioSourceWing.Play();
        }
    }
}
