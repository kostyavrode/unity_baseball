using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float minspeed;
    public float maxspeed;
    private float speed;
    public float livetime;
    private float wastedtime;
    public Rigidbody rb;
    private void Awake()
    {
        speed = Random.Range(minspeed, maxspeed);
    }
    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        wastedtime += Time.deltaTime;
        if (wastedtime>livetime)
        {
            StartCoroutine(WaitToDeath());
        }    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            GameManager.instance.AddScore();
            StartCoroutine(WaitToDeath());
            rb.useGravity = enabled;
            rb.AddForce(new Vector3(Random.Range(-1,1), Random.Range(0.5f, 1), Random.Range(-1f, -0.5f)) *600);
        }
    }
    private IEnumerator WaitToDeath()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
