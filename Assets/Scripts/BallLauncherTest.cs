using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncherTest : MonoBehaviour
{
    Vector3 direction;
    public float angle;

    [SerializeField]
    float force;



    [SerializeField]
    Rigidbody2D ball;

    public GameObject pointPrefab;

    public GameObject[] points;

    public int numberOfPoints;


    public float forceFactor;

    public float trajectoryParameter;


    public bool wasLaunch = false;

    public GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        direction = Quaternion.Euler(0, 0, angle) * Vector3.right;

        points = new GameObject[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!wasLaunch)
        {
            if (Input.GetButton("Space"))
            {
                force += Time.deltaTime * forceFactor*manager.difficultyFactor;

                for (int i = 0; i < points.Length; i++)
                {
                    points[i].transform.position = SetPointPosition(i * 0.1f);
                }
            }
            if (Input.GetButtonUp("Space") || force > 13f)
            {
                LaunchBall();
            }
        }
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
            point.transform.position = new Vector2(-7, -3);
        }

        force = 0;
    }


    Vector2 SetPointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + ((Vector2)direction.normalized * force * t)
        + 0.5f * Physics2D.gravity * (t * t);

        return currentPointPos;
    }
}
