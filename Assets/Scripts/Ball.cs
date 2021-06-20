using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    [SerializeField]
    private Hole hole;

    [SerializeField]
    private Vector2 startingPosition;

    [SerializeField]
    private float startingPositionX;

    [SerializeField]
    private Rigidbody2D ball;

    public PositionConverter converter;

    private float ProportionX;
    private float ProportionY;

    private void Start()
    {
        MeasureProportion();          
    }

    private void MeasureProportion()
    {
        startingPosition = new Vector2(startingPositionX, transform.position.y);
        ProportionX = converter.SetProportionX(startingPosition);
        ProportionY = converter.SetProportionY(startingPosition);
    }

    public void StartPosition()
    {
        transform.position = converter.ConvertToScreenPosition(ProportionX, ProportionY);   
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
