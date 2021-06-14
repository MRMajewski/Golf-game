using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField]
    GameManager manager;

    [SerializeField]
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetRandomPos()
    {
        Vector3 newSpawnPos = new Vector3(Random.Range(0, 7.5f), transform.position.y, transform.position.z);
        transform.position = newSpawnPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       manager.Win();
    }

}
