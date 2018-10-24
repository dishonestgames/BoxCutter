using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip[] jumpSounds;


	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Play(AudioClip clip)
    {
		audioSource.clip = clip;
		audioSource.Play();
	}

	public void PlayJump()
    {
		int index = Random.Range(0, jumpSounds.Length);
		AudioClip clip = jumpSounds[index];

		Play(clip);
	}
}
