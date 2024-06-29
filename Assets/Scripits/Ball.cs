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
    private bool isVibrate;
    private void Awake()
    {
        speed = Random.Range(minspeed, maxspeed);
    }
    private void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
        wastedtime += Time.deltaTime;
        if (wastedtime>livetime)
        {
            StartCoroutine(WaitToDeath());
        }
        if (isVibrate)
        {
            Handheld.Vibrate();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            GameManager.instance.AddScore();
            StartCoroutine(WaitToDeath());
            rb.useGravity = enabled;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(Random.Range(-1,1), Random.Range(0.5f, 1), Random.Range(1f, 0.5f)) *600);
            Debug.Log("Contact");
            StartCoroutine(WaitToVibrate());
        }
    }
    private IEnumerator WaitToDeath()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    private IEnumerator WaitToVibrate()
    {
        isVibrate = true;
        yield return new WaitForSeconds(0.5f);
        isVibrate = false;
    }
}
