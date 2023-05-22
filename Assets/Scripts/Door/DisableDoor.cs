using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reset door position and disables it when the player enters the trigger
public class DisableDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject handler;
    public GameHandler gameHandler;

    public GameObject lamb;
    public Material green;

    public bool isTutorialDoor;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody rb;
    private Material red;

    // whether the door is disabled
    private bool disabled;

    // Start is called before the first frame update
    void Start()
    {
        disabled = false;
        Transform t = door.GetComponent<Transform>();
        rb = door.GetComponent<Rigidbody>();
        initialPosition = t.position;
        initialRotation = t.rotation;

        red = lamb.GetComponent<MeshRenderer>().material;
        if(isTutorialDoor) {
            lamb.GetComponent<MeshRenderer>().material = green;
        }
    }

    // when the player enters the trigger
    private void OnTriggerExit(Collider someObject) {
        // already disabled
        if (disabled) return;
        if (someObject.gameObject.layer == 8)
        {
            Disable();
        }
    }

    private void Disable() {
        // disable rigidbody
        rb.isKinematic = true;

        door.transform.position = initialPosition;
        door.transform.rotation = initialRotation;
        // disable grabbable handler
        handler.SetActive(false);
        disabled = true;

        //red light on
        lamb.GetComponent<MeshRenderer>().material = red;
        if(gameHandler != null) {
            gameHandler.NextLevel();
        }
    }
    
    public void Enable() {
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        door.transform.position = initialPosition;
        door.transform.rotation = initialRotation;

        // disable grabbable handler
        handler.SetActive(true);
        disabled = false;

        // green light on
        lamb.GetComponent<MeshRenderer>().material = green;
    }

}
