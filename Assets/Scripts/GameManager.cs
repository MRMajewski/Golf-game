using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public Hole hole;
    public Ball ball;
    // public BallLauncher launcher;
    public BallLauncherTest launcher;

    public float shotSpeed = 1;
    [SerializeField]
    private int points;
    [SerializeField]
    private int highScore;

    public float difficultyFactor = 1;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        highScore = 0;
        PlayerPrefs.SetInt("HighScore", highScore);
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
            if (ball.isBallOutOfBounds())
            {
                GameOver();
            }
        }      
    }

    public void StartLevel()
    {
        difficultyFactor = 1;
        points = 0;
        uiManager.UpdatePoints();
        NextLevel();
    }

    public void GameOver()
    {
        uiManager.UpdateScore();
        uiManager.UpdateHighScore();
        uiManager.OpenGameOverScreen();
        ball.StartPosition();
    }

    public void Win()
    {
        points++;
        if(points>highScore )
        {
            highScore = points;           
        }
        uiManager.UpdatePoints();
        NextLevel();
        difficultyFactor += 0.25f;

    }

    public void NextLevel()
    {

        ball.StartPosition();
        hole.SetRandomPos();
        launcher.wasLaunch = false;
        uiManager.CloseGameOverScreen();
    }

    public int GetPoints()
    {
        return points;
    }

    public int GetHighScore()
    {
        return highScore;
    }
}
