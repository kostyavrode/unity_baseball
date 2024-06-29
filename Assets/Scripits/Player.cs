using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Collider collider;
    public Animator animator;
    private float cd = 3;
    public bool isCanAttack;
    public AudioSource audio;
    private void Awake()
    {
        collider.enabled = false;
        StartCoroutine(WaitToCD());
    }
    private void Start()
    {
        isCanAttack = false;
    }
    private void Update()
    {
        if (GameManager.instance.IsGameStarted() && isCanAttack)
        {
            if (Input.GetMouseButtonUp(0))
            {
                StartCoroutine(WaitToCD());
                StartCoroutine(WaitToActivateCollider());
                
                animator.SetTrigger("strike");
                isCanAttack = false;
                StartCoroutine(WaitToAudio());
            }
        }
    }
    private IEnumerator WaitToActivateCollider()
    {
        yield return new WaitForSeconds(0.3f);
        collider.enabled = true;
        StartCoroutine(WaitToDeActivateCollider());
    }
    private IEnumerator WaitToDeActivateCollider()
    {
        yield return new WaitForSeconds(1);
        collider.enabled = false;
    }
    private IEnumerator WaitToCD()
    {
        yield return new WaitForSeconds(1.5f);
        isCanAttack = true;
    }
    private IEnumerator WaitToAudio()
    {
        yield return new WaitForSeconds(0.5f);
        audio.Play();
    }
}
