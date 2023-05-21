using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawProgress : MonoBehaviour
{
    
    public DisableDoor doorToEnable;
    private bool isFinished;
    private PieceScript[] allChildren;

    // Start is called before the first frame update
    void Start()
    {
        isFinished = false;
        allChildren = GetComponentsInChildren<PieceScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameFinished()) {
            // open door
            doorToEnable.Enable();
        }
    }

    bool isGameFinished() {
        foreach (PieceScript child in allChildren)
        {
            if (!child.foundRightPosition) return false;
        }
        return true;
    }
}
