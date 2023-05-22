using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBottomScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider someObject)
    {
        if (someObject.CompareTag("Candy"))
        {
            Rigidbody body = someObject.gameObject.transform.GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }

    private void OnTriggerExit(Collider someObject)
    {
        if (someObject.CompareTag("Candy"))
        {
            Rigidbody body = someObject.gameObject.transform.GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.None;
        }
    }
}
