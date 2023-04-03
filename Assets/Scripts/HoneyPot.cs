using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( "This is just a simple log lost among others :'-( " );

		Debug.LogWarning( "This is a warning way easier to find :-) " );

		int useless_int = 123456;
		Debug.LogWarning(useless_int);

		// Debug.LogError( "This is an error ;-) !" );

		// int[] array = new int[1];
		// array[1] = 42;   // This will raise an error 
    }
}
