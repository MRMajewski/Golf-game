using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField]
    private GameManager manager;
    [SerializeField]
    private Ball ball;

    [SerializeField]
    private PositionConverter converter;

    [SerializeField]
    private float spawnRangeXMax;
    [SerializeField]
    private float spawnRangeXMin;

    private float PropX;
    private float PropY;

    public bool isBallInHole = false;



    public void SetRandomPos()
    {

        Vector2 newSpawnPos = new Vector2(Random.Range(spawnRangeXMin, spawnRangeXMax), transform.position.y);

        MeasureProportion(newSpawnPos);

        transform.position = converter.ConvertToScreenPosition(PropX, PropY);

        isBallInHole = false;
    }

    private void MeasureProportion(Vector2 newSpawnPos)
    {
        PropX = converter.SetProportionX(newSpawnPos);
        PropY = converter.SetProportionY(newSpawnPos);
    }


        private void OnTriggerEnter2D(Collider2D collision)
    {
       isBallInHole = true;
    }

   


}
