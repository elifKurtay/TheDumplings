using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reset door position and disables it when the player enters the trigger
public class DisableDoor : MonoBehaviour
{
    public GameObject door;
    public DisableDoor otherDoor;
    public GameObject handler;
    public GameHandler gameHandler;
    // public Collider trigger;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    // whether the door is disabled
    private bool disabled;

    // Start is called before the first frame update
    void Start()
    {
        Transform t = door.GetComponent<Transform>();
        initialPosition = t.position;
        initialRotation = t.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the player enters the trigger
    private void OnTriggerExit(Collider someObject) {
        // already disabled
        if (disabled) return;
        if (someObject.gameObject.layer == 8)
        {
            Disable();
            if(gameHandler != null) {
                gameHandler.NextLevel();
            }
        }
    }

    private void Disable() {
        // disable rigidbody
        Rigidbody rb = door.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        door.transform.position = initialPosition;
        door.transform.rotation = initialRotation;
        // disable grabbable handler
        handler.SetActive(false);
        otherDoor.Enable();
        disabled = true;
    }
    
    public void Enable() {
        Rigidbody rb = door.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        door.transform.position = initialPosition;
        door.transform.rotation = initialRotation;

        // disable grabbable handler
        handler.SetActive(true);
        disabled = false;
    }

}
