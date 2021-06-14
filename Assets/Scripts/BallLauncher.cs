using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    Vector3 direction;
    public float angle;

    [SerializeField]
    float force;

  

    [SerializeField]
    Rigidbody2D ball;

    public GameObject pointPrefab;

    public GameObject[] points;

    public List<GameObject> pointsList;

    public int numberOfPoints;

    float timeForTrajectoryDot;

    public float forceFactor;

    public float trajectoryParameter;

    public float trajectoryDotRespawnTime;

    public bool wasLaunch = false;


    // Start is called before the first frame update
    void Start()
    {
        timeForTrajectoryDot = 0;
           direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
    
        pointsList = new List<GameObject>();

        //for (int i = 0; i < numberOfPoints; i++)
        //{
        //    points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
        //}

        //for (int i = 0; i < pointsList.Count; i++)
        //{
        //    pointsList[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (!wasLaunch)
        {
            if (Input.GetButton("Space"))
            {
                force += Time.deltaTime * forceFactor;

                timeForTrajectoryDot += Time.deltaTime * trajectoryParameter;

                if (timeForTrajectoryDot >= trajectoryDotRespawnTime && pointsList.Count < 21)
                {
                    {
                        pointsList.Add(Instantiate(pointPrefab, transform.position, Quaternion.identity, transform.parent));
                    }

                    for (int i = 0; i < pointsList.Count; i++)
                    {

                        pointsList[i].transform.position = SetPointPosition(i * 0.1f);

                        if (pointsList.Count > 20)
                        {
                            Destroy(pointsList[i]);
                            pointsList.Remove(pointsList[i]);
                        }

                    }
                    timeForTrajectoryDot = 0;
                }

                //for (int i = 0; i < points.Length; i++)
                //{
                //    points[i].transform.position = SetPointPosition(i * 0.1f);
                //}
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
        ResetTrayectory();
        wasLaunch = true;
    }

    void ResetTrayectory()
    {
        foreach (GameObject point in pointsList)
        {
            Destroy(point);
        }
        pointsList.Clear();

        force = 0;
    }


    Vector2 SetPointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2) transform.position + ((Vector2)direction.normalized * force * t) 
        + 0.5f * Physics2D.gravity * (t * t);

        return currentPointPos;
    }
}
