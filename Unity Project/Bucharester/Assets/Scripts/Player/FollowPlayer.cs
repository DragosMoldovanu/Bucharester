using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float rotationSpeed;

    private float rotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rotation -= rotationSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotation += rotationSpeed * Time.deltaTime;
        }

        // Keep Rotation Finite
        if (rotation > 2 * Mathf.PI)
        {
            rotation -= 2 * Mathf.PI;
        }
        if (rotation < 0)
        {
            rotation += 2 * Mathf.PI;
        }

        transform.position = player.transform.position + new Vector3(offset * Mathf.Cos(rotation), offset, offset * Mathf.Sin(rotation));
        transform.LookAt(player.transform);
    }
}
