using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float acceleration;
    public float speed;
    public float collisionBoundary;

    public bool canMove = true;
    public Vector3 direction;

    public Animator squashStretchAnimator;

    public GameObject sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            
            direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                direction += (transform.up + transform.forward).normalized;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction -= (transform.up + transform.forward).normalized;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction -= transform.right;
                sprite.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction += transform.right;
                sprite.transform.localEulerAngles = new Vector3(0, 180, 0);
            }
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                if (squashStretchAnimator != null)
                {
                    squashStretchAnimator.SetTrigger("Idle");
                }
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            else if (squashStretchAnimator != null)
            {
                squashStretchAnimator.SetTrigger("Walk");
            }

            Debug.DrawRay(transform.position, direction.normalized * collisionBoundary);
            RaycastHit hit;
            if (!Physics.Raycast(transform.position, direction, out hit, collisionBoundary))
            {
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                Debug.Log(hit.collider.gameObject.name);
            }
        }
    }

    void FixedUpdate()
    {
        /*
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(transform.position + direction.normalized * acceleration * Time.deltaTime);
        if (body.velocity.magnitude > speed)
        {
            body.velocity = body.velocity.normalized * speed;
        }
        */
    }
}
