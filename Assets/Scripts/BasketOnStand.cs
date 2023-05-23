using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketOnStand : MonoBehaviour
{
    public CandyCounter counter;
    private Vector3 centerPosition;
    // Start is called before the first frame update
    void Start()
    {
        centerPosition = transform.position;
    }

    private void OnTriggerEnter(Collider someObject)
    {
        if (someObject.CompareTag("Basket"))
        {
            someObject.gameObject.transform.position = centerPosition;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            BasketCollisionScript basketContent = other.gameObject.GetComponentInChildren<BasketCollisionScript>();
            counter.candyCount = basketContent.numberOfCandies;
        }
    }
    private void OnTriggerExit(Collider someObject)
    {
        if (someObject.CompareTag("Basket"))
        {
            counter.candyCount = 0;
        }
    }
}
