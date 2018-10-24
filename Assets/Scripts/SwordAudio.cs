using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAudio : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip[] audioClips;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void PlayClip() {
        int index = Random.Range(0, audioClips.Length);
        AudioClip clip = audioClips[index];
        audioSource.clip = clip;
        audioSource.Play();
    }
}
