using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private Vector3 direction;
    private float force;
    private GameObject[] points;

    [SerializeField]
    private Rigidbody2D ball;
    [SerializeField]
    private GameObject pointPrefab;
    [SerializeField]
    private Transform trajectoryParent;
    [SerializeField]
    private GameManager manager;

    public bool wasLaunch = false;

    [Header("Changeable factors")]

    [SerializeField]
    private float angle;
    [SerializeField]
    private int numberOfPoints;
    [SerializeField]
    private float forceFactor;
    [SerializeField]
    private float maximumForce;
    [SerializeField]
    private Vector2 trajectoryResetPos;


    void Start()
    {
        direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
        CreateTrajectory();
    }

    void Update()
    {
        if (!wasLaunch)
        {
            if (Input.GetKey(KeyCode.Space))
            {            
                UpdateTrajectory();
            }
            if (Input.GetKeyUp(KeyCode.Space) || force > maximumForce)
            {
                LaunchBall();
            }
        }
    }

    void CreateTrajectory()
    {
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
