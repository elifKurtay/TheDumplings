using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFollowsCamera : MonoBehaviour
{
    public Camera camera;

    // public CapsuleCollider collider;

    // public GameObject playerController;
    private CharacterController controller;
    // protected OVRCameraRig CameraRig = null;
    private float initialY;
    
    // Start is called before the first frame update
    void Start()
    {
        // collider = GetComponent<CapsuleCollider>();
        controller = GetComponent<CharacterController>();
        initialY = controller.center.y;

        InvokeRepeating("UpdateControllerPosition", 0, 0.5f); 
    }

    // Update is called once per frame
    void Update()
    {   
    }

    private void UpdateControllerPosition() {
        Vector3 newPos = camera.transform.localPosition;
        // temp.y = collider.transform.position.y;
        // Vector3 temp = camera.transform.localPosition;
        // temp.y = collider.transform.position.y;
        // collider.transform.position = temp;
        newPos.y = initialY;
        controller.center = newPos;
    }
}
