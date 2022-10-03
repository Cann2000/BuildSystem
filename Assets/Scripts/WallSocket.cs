using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSocket : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
