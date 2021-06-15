using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Hole hole;

    [SerializeField]
    private Vector2 startingPosition;

    private Rigidbody2D ball;

     private void Start()
    {
        ball = GetComponent<Rigidbody2D>();
    }

    public void StartPosition()
    { 
        transform.position = startingPosition;
        ball.velocity = new Vector2(0, 0);
        ball.angularVelocity = 0f;
    }


    public bool isBallOutOfBounds()
    {
        if (transform.position.x > hole.transform.position.x)
            return true;
        else  return false;
    }

}
