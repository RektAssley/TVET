using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Renderer))] // force renderer to be attached
public class KeepWithinScreen : MonoBehaviour
{
    private Renderer rend;
    private Camera cam; //camera container
    private Bounds camBounds;
    private float camWidth, camHeight;

    void Start()
    {
        //set camera vari to main camera
        cam = Camera.main;
        rend = GetComponent<Renderer>();
    }
    void UpdateCamBounds()
    {
        //calculate camera bounds
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        camBounds = new Bounds(cam.transform.position, new Vector3(camWidth, camHeight));
    }
    Vector3 CheckBounds()
    {
        Vector3 pos = transform.position;
        Vector3 size = rend.bounds.size;
        float halfWidth = size.x * 0.5f;
        float halfHeight = size.y * 0.5f;
        float halfCamWidth = camWidth * 0.5f;
        float halfCamheight = camHeight * 0.5f;
        //left
        if (pos.x - halfWidth < camBounds.min.x)
        {
            pos.x = camBounds.min.x + halfWidth;
        }
        //right
        if (pos.x + halfWidth > camBounds.max.x)
        {
            pos.x = camBounds.max.x - halfWidth;
        }
        //down
        if (pos.y - halfHeight < camBounds.min.y)
        {
            pos.y = camBounds.min.y + halfHeight;
        }
        //Up
        if (pos.y + halfHeight > camBounds.max.y)
        {
            pos.y = camBounds.max.y + halfHeight;
        }
        return pos;
    }
    void Update()
    {
        UpdateCamBounds();
        transform.position = CheckBounds();
    }
}
