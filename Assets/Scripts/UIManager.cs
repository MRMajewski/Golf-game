using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameManager manager;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private TextMeshProUGUI points;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void CloseGameOverScreen()
    {
        gameOverPanel.SetActive(false);
    }

    public void OpenGameOverScreen()
    {
        gameOverPanel.SetActive(true);
    }

    public void UpdatePoints()
    {
        points.text = manager.GetPoints().ToString();
    }

    public void UpdateScore()
    {
        scoreText.text = "SCORE: " + manager.GetPoints().ToString();
    }

    public void UpdateHighScore()
    {
        highScoreText.text = "BEST: "+ manager.GetHighScore().ToString();
    }
}
