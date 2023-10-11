using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjects : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public bool rotateClockwise = true; // Set this to false if you want to rotate counterclockwise

    void Update()
    {
        RotateObjectAroundZAxis();
    }

    private void RotateObjectAroundZAxis()
    {
        float direction = rotateClockwise ? 1f : -1f;
        transform.Rotate(Vector3.forward * rotationSpeed * direction * Time.deltaTime);
    }
}
