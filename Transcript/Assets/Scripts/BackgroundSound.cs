using UnityEngine;
using System.Collections;
using UnityEditor.Audio;



public class BackgroundSound : MonoBehaviour {

	public string url;
	AudioSource source;

	// Use this for initialization
	IEnumerator Start () {
		WWW www = new WWW (url);

		if(!source.isPlaying && source.clip.isReadyToPlay) {
			source.Play();
		}

		yield return www;

		source = GetComponent<AudioSource> ();
		source.clip = www.audioClip;
	}
	
	// Update is called once per frame
	void Update () {
		if (source == null || source.clip == null) {
			return;
		}

		if(!source.isPlaying && source.clip.isReadyToPlay) {
			source.Play();
		}
	}
}




