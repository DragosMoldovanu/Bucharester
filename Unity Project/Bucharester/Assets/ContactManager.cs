using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactManager : MonoBehaviour
{
    public GameObject contactsContainer;
    public GameObject contactPrefab;

    void OnEnable()
    {
        foreach (Transform contact in contactsContainer.transform)
        {
            Destroy(contact.gameObject);
        }

        foreach (string contact in Database.contactsDatabase)
        {
            GameObject contactObject = Instantiate(contactPrefab, contactsContainer.transform);
            contactObject.GetComponent<ContactController>().SetData(contact, contact);
        }
    }
}
