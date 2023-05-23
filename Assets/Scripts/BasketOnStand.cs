using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketOnStand : MonoBehaviour
{
    public CandyCounter counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider someObject)
    {
        if (someObject.CompareTag("Basket"))
        {
            BasketCollisionScript basketContent = someObject.gameObject.transform.GetComponentInChildren<BasketCollisionScript>();
            counter.candyCount = basketContent.numberOfCandies;
            someObject.gameObject.transform.localPosition = Vector3.zero;
            someObject.gameObject.transform.localRotation = Quaternion.identity;
            Rigidbody body = someObject.gameObject.transform.GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
    }

    private void OnTriggerExit(Collider someObject)
    {
        if (someObject.CompareTag("Basket"))
        {
            counter.candyCount = 0;
            Rigidbody body = someObject.gameObject.transform.GetComponent<Rigidbody>();
            body.constraints = RigidbodyConstraints.None;
        }
    }
}
