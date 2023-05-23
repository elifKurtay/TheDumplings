using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reset door position and disables it when the player enters the trigger
public class DisableDoor : MonoBehaviour
{
    public GameHandler gameHandler;
    public GameObject door;
    public GameObject grabbableHandle;

    public GameObject lamb;
    // public Material red;
    public Material green;

    public bool isTutorialDoor;

    private Vector3 doorInitPos;
    private Quaternion doorInitRot;
    private Rigidbody doorRb;

    private Vector3 handleInitPos;

    private Material red;

    // whether the door is disabled
    private bool disabled;

    // Start is called before the first frame update
    void Start()
    {
        disabled = true;
        Transform t = door.GetComponent<Transform>();
        doorRb = door.GetComponent<Rigidbody>();
        doorInitPos = t.position;
        doorInitRot = t.rotation;
        handleInitPos = grabbableHandle.GetComponent<Transform>().position;

        red = lamb.GetComponent<MeshRenderer>().material;
        if(isTutorialDoor) {
            Enable();
            
            // DEBUG ONLY
            // StartCoroutine(waiter());
        }
    }

    // DEBUG ONLY
    IEnumerator waiter() {
        Disable();

        yield return new WaitForSeconds(5);

        Enable();
    }

    // when the player enters the trigger
    private void OnTriggerExit(Collider someObject) {
        if (someObject.gameObject.layer == 8)
        {
            Disable();
        }
    }

    private void Disable() {
        // already disabled
        if (disabled) return;

        // disable rigidbody
        doorRb.isKinematic = true;

        ResetDoorPosition();

        // disable grabbable handler
        grabbableHandle.SetActive(false);
        
        // door.SetActive(true);

        //red light on
        lamb.GetComponent<MeshRenderer>().material = red;
        if(gameHandler != null) {
            gameHandler.NextLevel();
        }
        disabled = true;
    }
    
    public void Enable() {
        // already enabled
        if (!disabled) return;

        ResetDoorPosition();

        // enable grabbable handler
        grabbableHandle.SetActive(true);

        doorRb.isKinematic = false;

        // green light on
        lamb.GetComponent<MeshRenderer>().material = green;

        disabled = false;
    }

    // reset position, rotation and velocity of movable components of the door
    private void ResetDoorPosition() {
        doorRb.velocity = Vector3.zero;
        doorRb.angularVelocity = Vector3.zero;

        door.transform.position = doorInitPos;
        door.transform.rotation = doorInitRot;

        grabbableHandle.transform.position = handleInitPos;
    }

}
