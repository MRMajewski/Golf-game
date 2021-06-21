using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private Hole hole;   
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private Rigidbody2D ballRigidbody;
    [SerializeField]
    private BallLauncher launcher;

    private int points;
    private int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HIGHSCORE", highScore);
        StartLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartLevel();
        }

        if(launcher.wasLaunch)
        {
            if (ball.isBallOutOfBounds() || ballRigidbody.velocity.magnitude <= 0f)
            {
                GameOver();
            }

            if(hole.isBallInHole)
            {
                Win();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    private void StartLevel()
    {
        ResetScore();
        uiManager.UpdatePoints();
        NextLevel();
        Time.timeScale = 1;
    }

    private void NextLevel()
    {

        ball.StartPosition();
        hole.SetRandomPos();       
        launcher.wasLaunch = false;
        uiManager.CloseGameOverScreen();
        Time.timeScale = 1;
    }

    private void GameOver()
    {
        uiManager.UpdateScore();
        uiManager.UpdateHighScore();
        uiManager.OpenGameOverScreen();
        Time.timeScale = 0;

    }

    public void Win()
    {
        points++;
        if(points>highScore )
        {
            highScore = points;
            PlayerPrefs.SetInt("HIGHSCORE", highScore);
        }
        uiManager.UpdatePoints();
        NextLevel();
        launcher.difficultyFactor += 0.25f;
    }

    private void ResetScore()
    {
        launcher.difficultyFactor = 1;
        points = 0;
    }

    public int GetPoints()
    {
        return points;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
