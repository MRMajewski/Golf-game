using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    [SerializeField]
    private PositionConverter converter;
    [SerializeField]
    private Hole hole;
    [SerializeField]
    private Rigidbody2D ball;

    [SerializeField]
    private Vector2 startingPosition;

    private float ProportionX;
    private float ProportionY;

    private void Start()
    {
        MeasureProportion();          
    }

    private void MeasureProportion()
    {   
        ProportionX = converter.SetProportionX(startingPosition);
        ProportionY = converter.SetProportionY(startingPosition);
    }

    public void StartPosition()
    {
        transform.position = converter.ConvertToScreenPosition(ProportionX, ProportionY);   
       // transform.position = converter.ConvertToScreenConstant(startingPosition);
        ball.velocity = new Vector2(0, 0);
        ball.angularVelocity = 0f;
    }

    public bool isBallOutOfBounds()
    {
        if (transform.position.x > hole.transform.position.x)
            return true;
        else
            return false;
    }

}
