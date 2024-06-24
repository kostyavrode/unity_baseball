using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Collider collider;
    private void Awake()
    {
        collider.enabled = false;
    }
    private void Update()
    {
        if (GameManager.instance.IsGameStarted())
        {
            if (Input.GetMouseButtonUp(0))
            {
                collider.enabled = true;
                StartCoroutine(WaitToDeActivateCollider());
            }
        }
    }
    private IEnumerator WaitToDeActivateCollider()
    {
        yield return new WaitForSeconds(1);
        collider.enabled = false;
    }
}
