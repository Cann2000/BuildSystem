using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofSocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Roof"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Roof"))
        {
            Destroy(gameObject);
        }
    }
}
