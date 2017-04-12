using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // what object are we following
    public Transform followObject;

    // how smooth is the animation?
    float smoothing = 5f;

    // how far away is the camera from the object?
    Vector3 offset;


    // when the script starts, find out its offset
    void Start()
    {

        offset = transform.position - followObject.position;

    }

    // move the camera according to physics
    void FixedUpdate()
    {

        Vector3 targetPos = followObject.position + offset;
        if (targetPos.y < 0f)
        {
            targetPos.y = 0f;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);

    }

}
