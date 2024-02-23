using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JusticeHint : MonoBehaviour
{
    public GameObject childObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scanner")) // Change "Player" to the tag of the object you want to trigger the activation
        {
            // Activate the child object
            childObject.SetActive(true);
        }
    }
}
