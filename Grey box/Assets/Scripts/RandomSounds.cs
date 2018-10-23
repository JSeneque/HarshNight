using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour {
    // found this code here
    // https://answers.unity.com/questions/1161379/how-to-play-a-random-audio-clip-from-an-array-in-c.html

    public AudioSource randomSound;

    // a container for all the sounds
    public AudioClip[] audioSources;


    // Use this for initialization
    void Start () {
        CallAudio();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CallAudio()
    {
        Invoke("RandomSoundness", 10);
    }

    void RandomSoundness()
    {
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
        CallAudio();
    }
}
