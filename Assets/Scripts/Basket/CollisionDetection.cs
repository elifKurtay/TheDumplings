using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public GameObject light;
    public Material green;

    private AudioSource audioSource;
    private Material red;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        red = light.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider someObject) {
        if(someObject.CompareTag("Basketball")) {
            Debug.Log("GOAL!");
            audioSource.PlayOneShot(audioSource.clip);
            light.GetComponent<MeshRenderer>().material = green;
            StartCoroutine(Wait3Sec());
        }
    }

    IEnumerator Wait3Sec()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        light.GetComponent<MeshRenderer>().material = red;
        //After we have waited 5 seconds print the time again.
        //Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
