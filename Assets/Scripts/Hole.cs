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
    private float spawnRangeX;

    public void SetRandomPos()
    {
        Vector3 newSpawnPos = new Vector3(Random.Range(0, spawnRangeX), transform.position.y, transform.position.z);
        transform.position = newSpawnPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       manager.Win();
    }

}
