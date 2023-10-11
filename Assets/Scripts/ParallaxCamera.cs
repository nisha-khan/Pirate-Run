using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxCamera : MonoBehaviour 
{
    public delegate void ParallaxCameraDelegate(float deltaMovement);
    public ParallaxCameraDelegate onCameraTranslate;

    private float oldPositionX;

    void Start()
    {
        oldPositionX = transform.position.x;
    }

    void FixedUpdate()
    {
        // Only track horizontal movement (X-axis)
        if (transform.position.x != oldPositionX)
        {
            if (onCameraTranslate != null)
            {
                float delta = oldPositionX - transform.position.x;
                onCameraTranslate(delta);
            }

            oldPositionX = transform.position.x;
        }
    }
}
