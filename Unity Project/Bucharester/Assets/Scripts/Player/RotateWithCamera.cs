using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithCamera : MonoBehaviour
{
    private Camera cam;
    private float xRot;
    private float zRot;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        xRot = transform.eulerAngles.x;
        zRot = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, cam.transform.eulerAngles.y, transform.eulerAngles.z);
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(xRot, transform.eulerAngles.y, zRot);
    }
}
