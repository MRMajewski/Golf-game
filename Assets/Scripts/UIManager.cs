using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public GameManager manager;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    TextMeshProUGUI points;

    [SerializeField]
    TextMeshProUGUI scoreText;

    [SerializeField]
    TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
