using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionConverter:MonoBehaviour
{
    [SerializeField]
    private float resolutionExampleX;
    [SerializeField]
    private float resolutionExampleY;

    private Vector2 convertedPos;

    public float SetProportionX(Vector2 positionInWorld)
    {
        float xProportion = positionInWorld.x / Screen.width;
        return xProportion;
    }

    public float SetProportionY(Vector2 positionInWorld)
    {
        float yProportion = positionInWorld.y / Screen.height;
        return yProportion;
    }

    public Vector2 ConvertToScreenPosition(float xProportion, float yProportion)
    {
        convertedPos = new Vector2(xProportion * Screen.width, yProportion * Screen.height);
        return convertedPos;
    }

    public Vector2 ConvertToScreenConstant(Vector2 positionInWorld)
    {
        float xProportion = positionInWorld.x / resolutionExampleX;
        float yProportion = positionInWorld.y / resolutionExampleY;

        convertedPos = new Vector2(xProportion * Screen.width, yProportion * Screen.height);
        return convertedPos;
    }

}
