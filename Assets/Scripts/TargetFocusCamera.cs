﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Camera script used to position the focus of the camera between the player's mouse and the player sprite.
 */
public class TargetFocusCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private float smoothTime;
    private Vector3 velocity;

    // Update is called once per frame
    void LateUpdate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var bounds = new Bounds(target.position, Vector3.zero);
        bounds.Encapsulate(target.position);
        bounds.Encapsulate(mousePosition);

        Vector3 smooth = Vector3.SmoothDamp(transform.position, bounds.center + offset, ref velocity, smoothTime);
        smooth.z = -10f;
        transform.position = smooth;
        velocity.z = 0;
    }
}
