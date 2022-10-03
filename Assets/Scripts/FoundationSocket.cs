using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationSocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Foundation"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Foundation"))
        {
            Destroy(gameObject);
        }
    }
}
