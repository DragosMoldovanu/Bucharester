using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteractables : MonoBehaviour
{
    public float clipOffset;
    public float clickDistance;

    public GameObject player;
    public float interactRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clipPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, clipOffset));
            RaycastHit hit;
            if (Physics.Raycast(transform.position, clipPos - transform.position, out hit, clickDistance))
            {
                if (hit.collider.gameObject.tag == "Interactable" && Vector3.Distance(hit.collider.transform.position, player.transform.position) <= interactRange)
                {
                    hit.collider.GetComponent<Clickable>().Clicked();
                }
            }
        }
    }
}
