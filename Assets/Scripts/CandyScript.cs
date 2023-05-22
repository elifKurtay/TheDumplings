using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    public bool inBasket = false;
    private float remainingTime;
    MeshRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponentInChildren<MeshRenderer>(); 
        Invoke("destroyCandy", 20.0f);
        Invoke("toggleVisibility", 12.0f);
        remainingTime = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime >= 0)
        {
            remainingTime -= Time.deltaTime;
        }
        if (inBasket)
        {
            renderer.enabled = true;
            CancelInvoke("destroyCandy");
            CancelInvoke("toggleVisibility");
        }
    }
    void toggleVisibility()
    {
       
        renderer.enabled = !renderer.enabled;
        float period = 0.2f;
        if (remainingTime < 5.0f) period = 0.1f;
        else if (remainingTime < 3.0f) period = 0.05f;
        Invoke("toggleVisibility", period);
    }
    void destroyCandy()
    {
        Destroy(gameObject);
    }
}
