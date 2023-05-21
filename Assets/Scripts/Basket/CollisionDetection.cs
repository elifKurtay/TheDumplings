using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public Logger debug;
    public DisableDoor doorToEnable;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider someObject) {
        if(someObject.CompareTag("Basketball")) {
            if(debug != null) {
                debug.LogInfo("GOAL!");
            }
            doorToEnable.Enable();
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
