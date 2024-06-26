using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject ballPrefab;
    public Animator animator;
    private float wastedTime;
    public float delay;
    public float delayAnimation;
    private bool isAnimationPlayed;
    public void Update()
    {
        wastedTime += Time.deltaTime;
        if (wastedTime>=delay)
        {
            SpawnNewBall();
            wastedTime = 0;
            isAnimationPlayed = false;
        }
        else if (wastedTime>=delayAnimation && !isAnimationPlayed)
        {
            animator.SetTrigger("pitch");
            isAnimationPlayed = true;
        }
    }
    public void SpawnNewBall()
    {
        GameObject newBall=Instantiate(ballPrefab);
        newBall.transform.position = spawnPoint.position;
    }
}
