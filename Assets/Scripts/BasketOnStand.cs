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
            someObject.gameObject.transform.position = Vector3.zero;
            someObject.gameObject.transform.rotation = Quaternion.identity;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        BasketCollisionScript basketContent = other.gameObject.transform.GetComponentInChildren<BasketCollisionScript>();
        counter.candyCount = basketContent.numberOfCandies;
    }
    private void OnTriggerExit(Collider someObject)
    {
        if (someObject.CompareTag("Basket"))
        {
            counter.candyCount = 0;
        }
    }
}
