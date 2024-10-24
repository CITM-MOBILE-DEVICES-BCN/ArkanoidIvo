using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int lives = 3;

    public static GameManager instance;
    public Ball ball;
    public Player player;
    public int bricks = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    int score = 0;
    int highscore = 0;

    // Variable para controlar si el AutoPlay est� activado o no
    public bool isAutoPlayEnabled = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        scoreText.text = score.ToString();
        highscoreText.text = "Best: " + highscore.ToString();
    }

    public void LoseLive()
    {
        lives--;

        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        ball.ResetBall();
        player.ResetPlayer();
    }

    public void CheckLevelCompleted()
    {
        if (bricks <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Funci�n para alternar el AutoPlay (activar/desactivar)
    public void ToggleAutoPlay()
    {
        isAutoPlayEnabled = !isAutoPlayEnabled;
    }

    public void AddPoints(Brick brick)
    {
        switch (brick.brickHealth)
        {
            case 2:
                score += 10;
                Debug.Log(brick.brickHealth);
                break;
            case 1:
                score += 10;
                Debug.Log(brick.brickHealth);
                break;
            case 0:
                score += 25; //TE DA 300 - fixear
                Debug.Log(brick.brickHealth);
                break;

        }
        scoreText.text = scoreText.text = score.ToString();
    }
}