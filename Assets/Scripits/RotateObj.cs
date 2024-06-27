using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float rotateX;
    public float rotateY;
    public float rotateZ;
    private void Update()
    {
        if (Time.timeScale != 0)
            transform.Rotate(rotateX, rotateY, rotateZ);
    }
}
