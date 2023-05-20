using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reset door position and disables it when the player enters the trigger
public class DisableDoor : MonoBehaviour
{
    public GameObject door;
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
    private void OnTriggerEnter(Collider someObject) {
        // already disabled
        if (disabled) return;

        ResetAndDisableDoor();
        if(gameHandler != null) {
            gameHandler.NextLevel();
        }
        disabled = true;
    }

    private void ResetAndDisableDoor() {
        // disable rigidbody
        Rigidbody rb = door.GetComponent<Rigidbody>();
        rb.isKinematic = true;

        door.transform.position = initialPosition;
        door.transform.rotation = initialRotation;
        

        // reset door position
        // rb.MovePosition(initialPosition);
        // rb.MoveRotation(initialRotation);

        // rb.detectCollisions = false;

        // disable grabbable handler
        handler.SetActive(false);
    }

}
