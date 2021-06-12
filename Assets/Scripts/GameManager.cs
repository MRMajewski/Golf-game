using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public Hole hole;

    public float shotSpeed = 1;

    private int points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartLevel()
    {
        hole.SetRandomPos();
    }

    public void GameOver()
    {
        uiManager.OpenGameOverScreen();
    }

    public float GetPoints()
    {
        return points;
    }
}
