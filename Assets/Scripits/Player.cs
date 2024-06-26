using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Collider collider;
    public Animator animator;
    private float cd = 3;
    public bool isCanAttack;
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
                collider.enabled = true;
                StartCoroutine(WaitToDeActivateCollider());
                animator.SetTrigger("strike");
                isCanAttack = false;
            }
        }
    }
    private IEnumerator WaitToDeActivateCollider()
    {
        yield return new WaitForSeconds(1);
        collider.enabled = false;
    }
    private IEnumerator WaitToCD()
    {
        yield return new WaitForSeconds(3);
        isCanAttack = true;
    }
}
