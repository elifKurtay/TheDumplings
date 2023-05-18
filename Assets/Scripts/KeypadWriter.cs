using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadWriter : MonoBehaviour
{
    [SerializeField] public Logger debug;
    private TextMeshPro textArea;
    private int maxLen = 6;
    private string password = "863923";

    // Start is called before the first frame update
    void Start()
    {
        textArea = GetComponent<TextMeshPro>();
        textArea.enabled = true;
        textArea.text = string.Empty;
    }


    public void Add(string number)
    {
        if (textArea.text.Length < maxLen)
        {
            textArea.text += number;
        }
    }

    public void Delete()
    {
        if (textArea.text.Length > 0)
        {
            textArea.text = textArea.text.Substring(0, textArea.text.Length-1);
        }
    }

    public void Submit()
    {
        if (textArea.text == password)
        {
            debug.LogInfo("Success!!!");
        }
        else
        {
            debug.LogInfo("FAIL!!!");
        }
    }
}
