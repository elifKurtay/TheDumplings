using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadWriter : MonoBehaviour
{
    public GameHandler gameHandler;
    private AudioSource audio;

    private TextMeshPro textArea;
    private int maxLen = 6;
    private string password = "862339";

    // Start is called before the first frame update
    void Start()
    {
        textArea = GetComponent<TextMeshPro>();
        audio = GetComponent<AudioSource>();
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
            gameHandler.NextLevel();
        }
        else
        {
            audio.Play();
        }
    }
}
