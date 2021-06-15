using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private Vector3 direction;

    private float angle;

    private float force;

    private float forceFactor;

    private float maximumForce;

    [SerializeField]
    private Rigidbody2D ball;

    [SerializeField]
    private GameObject pointPrefab;

    private GameObject[] points;

    private int numberOfPoints;

    [SerializeField]
    private Vector2 trajectoryResetPos;

    [SerializeField]
    private Transform trajectoryParent;

    [SerializeField]
    private GameManager manager;

    public bool wasLaunch = false;

    void Start()
    {
        forceFactor = 5f;
        maximumForce = 13f;
        angle = 45f;
        direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
        CreateTrajectory();
    }

    void Update()
    {
        if (!wasLaunch)
        {
            if (Input.GetButton("Space"))
            {            
                UpdateTrajectory();
            }
            if (Input.GetButtonUp("Space") || force > maximumForce)
            {
                LaunchBall();
            }
        }
    }

    void CreateTrajectory()
    {
        numberOfPoints = 20;

        points = new GameObject[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity, trajectoryParent);
        }
    }

    void UpdateTrajectory()
    {
        force += Time.deltaTime * forceFactor * manager.difficultyFactor;

        for (int i = 0; i < points.Length; i++)
        {
            points[i].transform.position = SetPointPosition(i * 0.1f);
        }
    }

    Vector2 SetPointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position
            + ((Vector2)direction.normalized * force * t)
            + 0.5f * Physics2D.gravity * (t * t);

        return currentPointPos;
    }

    void LaunchBall()
    {

        ball.velocity = direction * force;
        ResetTrajectory();
        wasLaunch = true;
    }

    void ResetTrajectory()
    {
        foreach (GameObject point in points)
        {
            point.transform.position = trajectoryResetPos;
        }
        force = 0;
    }
}
