using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionConverter:MonoBehaviour
{
    private float xProportion;
    private float yProportion;
    private Vector2 convertedPos;


    public float SetProportionX(Vector2 positionInWorld)
    {
        xProportion = positionInWorld.x / Screen.width;
        return xProportion;
    }

    public float SetProportionY(Vector2 positionInWorld)
    {
        yProportion = positionInWorld.y / Screen.height;
        return yProportion;
    }

    public Vector2 ConvertToScreenPosition(float xProportion, float yProportion)
    {
        convertedPos = new Vector2(xProportion * Screen.width, yProportion * Screen.height);
        return convertedPos;
    }

}
