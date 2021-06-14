using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncherLine : MonoBehaviour
{
    Vector3 direction;
    public float angle;

    public float forceParameter = 1;

    float force;

    public LineRenderer line;
    public int lineSegment;


    [SerializeField]
    Rigidbody2D ball;

    public float x;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
        // width is the width of the line
        float width = line.startWidth;
        //line.material.mainTextureScale = new Vector2(1f / width, 1.0f);
      //  line.material.SetTextureScale("_MainTex", new Vector2(x, y));
        line.material.mainTextureScale = new Vector2(x, y);


        direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
        line.positionCount = lineSegment;
    }

    // Update is called once per frame
    void Update()
    {
        line.material.mainTextureScale = new Vector2(x,y);

        //  line.material.SetTextureScale("_MainTex", new Vector2(x, y));
        //  line.material.mainTextureScale = new Vector2(x, y);


        if (Input.GetButton("Space"))
        {


            force += Time.deltaTime * forceParameter;

           // VisualizeTrajectory(direction*force);
            VisualizeTest();

        }
        if (Input.GetButtonUp("Space"))
        {
            Debug.Log("Up button");
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        ball.velocity = direction * force;
    }

    void VisualizeTrajectory(Vector2 vo)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector2 pos = CalculatePositionInTime(vo, i / (float)lineSegment);
            line.SetPosition(i, pos);
        }
    }

    void VisualizeTest()
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector2 pos = SetPointPosition(i / (float)lineSegment);
            line.SetPosition(i, pos);
        }
    }

    Vector2 CalculatePositionInTime(Vector2 vo, float time)
    {
        Vector2 Vxz = vo;
        Vxz.y = 0f;

        Vector2 result = (Vector2)this.transform.position + vo * time;
        float sY = (-0.5f * Physics2D.gravity.y) * (time * time) + (vo.y * time) + transform.position.y;

       
        result.y = sY;

        return result;
    }

    Vector2 SetPointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + ((Vector2)direction.normalized * force * t)
        + 0.5f * Physics2D.gravity * (t * t);

        return currentPointPos;
    }
}
