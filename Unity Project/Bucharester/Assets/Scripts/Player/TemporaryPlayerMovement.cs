using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryPlayerMovement : MonoBehaviour
{
    float speed = 25;
    Vector3 direction = new Vector3();

    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        direction = new Vector3(xMov, 0, zMov).normalized;

        transform.position += direction * speed * Time.deltaTime;
        
    }
}
