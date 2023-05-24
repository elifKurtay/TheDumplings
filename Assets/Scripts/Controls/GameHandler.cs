using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public AudioClip musicInit;

    public GameObject room2;
    public GameObject endingScene;

    public List<GameObject> interactables;

    private int gameLevel;
    private bool updated;

    // Start is called before the first frame update
    void Start()
    {
        gameLevel = 0;
        updated = false;

        //background music
        AudioSource musicSource = GetComponent<AudioSource>();
        musicSource.PlayOneShot(musicInit);
        musicSource.PlayScheduled(AudioSettings.dspTime + musicInit.length);

        // activate first 2 rooms interactables
        interactables[0].SetActive(true);
        interactables[1].SetActive(true);
        for( int i = 2; i < interactables.Count; i++){
            interactables[i].SetActive(false);
        }
        endingScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(updated) {
            if(gameLevel == 4) {
                interactables[gameLevel-1].SetActive(false);
                updated = false;
                return;
            }
            else if (gameLevel == 5) {
                interactables[gameLevel-1].SetActive(false);
                endingScene.SetActive(true);
                room2.SetActive(false);
                updated = false;
                return;
            }

            interactables[gameLevel-1].SetActive(false);
            interactables[gameLevel+1].SetActive(true);
            updated = false;
        }
    }

    public void NextLevel() {
        if(gameLevel == 5) {
            return;
        }
        gameLevel++;
        updated = true;
    }
}
