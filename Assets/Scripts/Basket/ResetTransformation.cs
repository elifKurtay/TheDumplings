using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTransformation : MonoBehaviour
{
    public void reset() {
        transform.position = new Vector3(0.083f-0.208f, 1f + 0.506f, 1.12f-0.378f);
    }

}
