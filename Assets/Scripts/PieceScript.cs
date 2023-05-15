using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
public class PieceScript : MonoBehaviour
{
    private Vector3 rightPosition;
    private Quaternion rightRotation;
    private AudioSource audioData;

    private bool foundRightPosition;

    private Rigidbody rigidBody;
    private Grabbable grab;
    private PointableUnityEventWrapper pointer;

    // Start is called before the first frame update
    void Start()
    {
        rightPosition = transform.position;
        rightRotation = transform.rotation;
        transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 0.05f, Random.Range(0f, 1f));
        rigidBody = GetComponent<Rigidbody>();
        audioData = GetComponent<AudioSource>();
        grab = GetComponent<Grabbable>();
        pointer = GetComponent<PointableUnityEventWrapper>();
    }

    // Update is called once per frame
    void Update()
    {
        if(foundRightPosition && transform.hasChanged)
        {
            transform.position = rightPosition;
            transform.rotation = rightRotation;
            transform.hasChanged = false;
            return;
        }

        if(Vector3.Distance(transform.position,rightPosition) < 0.05f)
        {
            transform.position = rightPosition;
            transform.rotation = rightRotation;
            foundRightPosition = true;
            //Destroy(grab);
            //Destroy(pointer);
            grab.enabled = false;
            pointer.enabled = false;
            var physGab = GetComponent<PhysicsGrabbable>();
            physGab.enabled = false;
            rigidBody.isKinematic = true;
            audioData.Play();
            Transform childToRemove = this.transform.Find("HandGrabInteractable");
            childToRemove.parent = null;
            //GameObject childToRemove = this.transform.GetChild(1).gameObject;
            //childToRemove.SetActive(false);
            //rigidBody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        }   
    }
}