using UnityEngine;
using System.Collections;
using UnityEditor.Audio;



public class BackgroundSound : MonoBehaviour {

	public string url;
	AudioSource source;

	// Use this for initialization
	void Start () {
		WWW www = new WWW (url);

		source = GetComponent<AudioSource> ();
		source.clip = www.audioClip;
	

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (source.clip);
		Debug.Log (source.clip.isReadyToPlay);
		Debug.Log (source.clip.loadState);
		if(!source.isPlaying && source.clip.isReadyToPlay)
			source.Play();
	}
}




