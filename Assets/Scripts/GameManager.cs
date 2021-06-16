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

    public float difficultyFactor;

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();
        highScore = 0;        
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
    }

    private void NextLevel()
    {

        ball.StartPosition();
        hole.SetRandomPos();
        launcher.wasLaunch = false;
        uiManager.CloseGameOverScreen();
    }

    private void GameOver()
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

    private void ResetScore()
    {
        difficultyFactor = 1;
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
