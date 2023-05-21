using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessSound : MonoBehaviour
{
    private Material red;
    private AudioSource music;
    private bool playing;
    // Start is called before the first frame update
    void Start()
    {
        red = GetComponent<MeshRenderer>().material;
        music = GetComponent<AudioSource>();
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playing && GetComponent<MeshRenderer>().material != red) {
            music.Play();
            playing = true;
        }
        
        if(GetComponent<MeshRenderer>().material == red) {
            playing = false;
        }

    }
}
