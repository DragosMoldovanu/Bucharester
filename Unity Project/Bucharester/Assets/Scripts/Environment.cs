using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {

            Movement playerMov = GameObject.Find("Player").GetComponent<Movement>();
            playerMov.canMove = false;
            playerMov.GetComponent<Rigidbody>().AddForce(-playerMov.direction * 1000, ForceMode.Force);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name =="Player")
        {
            Movement playerMov = GameObject.Find("Player").GetComponent<Movement>();
            playerMov.canMove = true;

        }
    }
}
