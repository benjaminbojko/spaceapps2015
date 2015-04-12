using UnityEngine;
using System.Collections;
using Newtonsoft.Json;

[RequireComponent(typeof(TextAnimation))]
public class MainController : MonoBehaviour {

	public string jsonURL;
	public string audioURL;
	AudioSource audio;

	JSONLoader<SegmentContainer> loader;
	TextAnimation textAnimation;

	void Start ()
	{
		loader = new JSONLoader<SegmentContainer> ();

		audio = GetComponent<AudioSource> ();
		textAnimation = GetComponent<TextAnimation> ();
		textAnimation.animationCompleted += AnimationCompleted;

		StartCoroutine (LoadAudioAndAnimate ());
	}
	
	IEnumerator LoadAudioAndAnimate ()
	{
		
		audio.Stop ();
		
		WWW www = new WWW (audioURL);
		
		yield return www;
		
		audio.clip = www.audioClip;
		audio.Play();
		
		LoadNextAnimation ();
	}

	void LoadNextAnimation ()
	{
		StartCoroutine (loader.Load (jsonURL, LoadSuccess, LoadError));
	}

	void LoadSuccess (SegmentContainer container)
	{
		Debug.Log ("Loaded " + container.Segments.Count + " segments");

		textAnimation.StartAnimation (container);
	}

	void LoadError (string error)
	{
		Debug.Log ("Error loading files: " + error);
	}

	void AnimationCompleted (TextAnimation animation)
	{
		LoadAudioAndAnimate ();
	}

}
