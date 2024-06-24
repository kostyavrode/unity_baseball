using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject ballPrefab;
    private float wastedTime;
    public float delay;
    public void Update()
    {
        wastedTime += Time.deltaTime;
        if (wastedTime>=delay)
        {
            SpawnNewBall();
            wastedTime = 0;
        }
    }
    public void SpawnNewBall()
    {
        Instantiate(ballPrefab, spawnPoint);
    }
}
