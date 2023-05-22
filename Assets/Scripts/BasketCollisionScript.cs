using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketCollisionScript : MonoBehaviour
{
    public Logger debug;
    private AudioSource audioSource;
    public int numberOfCandies=0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider someObject)
    {
        if (someObject.CompareTag("Candy"))
        {
            debug.LogInfo("New Candy");
            CandyScript candyState = someObject.gameObject.GetComponent<CandyScript>();
            someObject.gameObject.transform.SetParent(gameObject.transform.parent);
            debug.LogInfo(candyState.inBasket.ToString());
            candyState.inBasket = true;
            debug.LogInfo(candyState.inBasket.ToString());
            audioSource.PlayOneShot(audioSource.clip);
            numberOfCandies += 1;
            debug.LogInfo(numberOfCandies.ToString());
        }
    }
    private void OnTriggerExit(Collider someObject)
    {
        if (someObject.CompareTag("Candy"))
        {
            debug.LogInfo("Candy left");
            numberOfCandies -= 1;
            debug.LogInfo(numberOfCandies.ToString());
        }
    }


}
