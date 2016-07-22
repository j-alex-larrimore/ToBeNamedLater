using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

	public static SoundController Instance;
	public AudioSource audioSource;

	private void Awake(){
		if (Instance != null && Instance != this) {
			DestroyImmediate(this);
			return;
		}

		Instance = this;
		DontDestroyOnLoad (gameObject);
	}

	public void PlaySingle(AudioClip clip){
		audioSource.clip = clip;
		audioSource.Play ();
	}
}
