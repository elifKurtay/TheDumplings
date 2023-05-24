using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CandyCounter : MonoBehaviour
{
    public DisableDoor doorToEnable;

    private TextMeshPro textArea;
    public int goalCount = 10;
    public int candyCount;

    // Start is called before the first frame update
    void Start()
    {
        textArea = GetComponent<TextMeshPro>();
        textArea.enabled = true;
        textArea.text = string.Empty;
        candyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textArea.text = candyCount.ToString() + "/10";
        if(candyCount >= goalCount) {
            doorToEnable.Enable();
        }
    }
}
