using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
public class PieceScript : MonoBehaviour
{
    private Vector3 rightPosition;
    private Quaternion rightRotation;
    private AudioSource audioData;

    public bool foundRightPosition = false;

    private Rigidbody rigidBody;
    private Grabbable grab;

    private GameObject piece;
    private Transform pieceTransform;
    private Quaternion pieceRotationOrig;
    private Vector3 piecePositionOrig;

    // Start is called before the first frame update
    void Start()
    {
        rightPosition = transform.position;
        rightRotation = transform.rotation;
        transform.localPosition = transform.localPosition + new Vector3(Random.Range(-25.0f,25.0f), Random.Range(0.3f, 0.5f),Random.Range(10.0f, 40.0f));
        
        rigidBody = GetComponent<Rigidbody>();
        audioData = GetComponent<AudioSource>();
        grab = GetComponent<Grabbable>();

        piece = GetComponentInChildren<SpriteRenderer>().gameObject;
        pieceTransform = piece.GetComponent<Transform>();
        pieceRotationOrig = pieceTransform.rotation;
        piecePositionOrig = pieceTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (foundRightPosition)
        {
            if( transform.hasChanged || pieceTransform.hasChanged) {
                pieceTransform.localPosition = Vector3.zero;
                pieceTransform.rotation = pieceRotationOrig;

                transform.position = rightPosition;
                transform.rotation = rightRotation;
                transform.hasChanged = false;
            }
            return;
        }
        

        // gets called only once
        if(Vector3.Distance(transform.position,rightPosition) < 0.05f && 
            Vector3.Distance(pieceTransform.rotation.eulerAngles, pieceRotationOrig.eulerAngles) < 35f)
        {
            Debug.Log(transform.position);
            Debug.Log(rightPosition);
            transform.position = rightPosition;
            transform.rotation = rightRotation;
            
            // for the grab box
            grab.enabled = false;
            var physGab = GetComponent<PhysicsGrabbable>();
            physGab.enabled = false;
            rigidBody.isKinematic = true;

            // for the piece
            var pieceRb = piece.GetComponent<Rigidbody>();
            pieceRb.isKinematic = true;
            pieceRb.angularVelocity = Vector3.zero;

            var pieceGrab = piece.GetComponent<Grabbable>();
            pieceGrab.enabled = false;
            
            pieceTransform.position = piecePositionOrig;
            pieceTransform.rotation = pieceRotationOrig;
            Debug.Log(pieceTransform.position);

            // general
            foundRightPosition = true;
            audioData.Play();
        }   
    }
}
