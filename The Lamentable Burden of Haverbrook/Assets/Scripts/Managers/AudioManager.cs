using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	const string MASTER_VOLUME_NAME = "MasterVolume";
	const string MUSIC_VOLUME_NAME = "MusicVolume";
	const string SFX_VOLUME_NAME = "SFXVolume";

	const float DEFAULT_FADE_TIME = .75f;

	static private AudioManager s_instance;
	static public AudioManager instance
	{
		get {
			if (s_instance != null)
				return s_instance;

			s_instance = FindObjectOfType<AudioManager>();

			if (s_instance == null)
				Debug.LogError ("There must be exactly one Audiomanager in the scene!");
			else
			{
				DontDestroyOnLoad (s_instance.gameObject);
			}
			return s_instance;
		}
	}

	public AudioMixer mixer;
	
	public AudioSource sfxSource;
	public AudioSource bgMusic;
	public AudioSource bgMusic2;

	public AudioClip[] sfxSounds;
	public AudioClip[] bgMusicClips;

	void Awake()
	{
		if(this != instance)
		{
			Destroy(this.gameObject);
			return;
		}
	}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.S))
			changeTrack(bgMusic, bgMusicClips[1], 100);

		if(Input.GetKeyDown(KeyCode.Q))
			changeTrack(bgMusic, bgMusicClips[0], 100);
	}

	IEnumerator fade_volume_to(AudioSource audioSource, float volume, float duration)
	{
		float fadeProgress = 0;
		float startingVolume = audioSource.volume;

		while(audioSource.volume != volume)
		{
			audioSource.volume = Mathf.Lerp(startingVolume, volume, Mathf.Clamp01(fadeProgress / duration));
			fadeProgress += Time.deltaTime;
			yield return null;
		}
		audioSource.volume = volume;
	}

	public static void PlaySound(AudioSource source, AudioClip clip, float volume)
	{
		instance.sfxSource.PlayOneShot(clip, volume);
	}

	public static void changeTrack(AudioSource source, AudioClip clip, float volume)
	{
		
		if(instance.bgMusic.isPlaying)
		{
			float currentTime = instance.bgMusic.time;
			instance.bgMusic.Stop();
			instance.bgMusic2.clip = clip;
			instance.bgMusic2.Play();
			instance.bgMusic2.time = currentTime;
		}
	
		else//(instance.bgMusic2.isPlaying)
		{
			float currentTime = instance.bgMusic2.time;
			instance.bgMusic2.Stop();
			instance.bgMusic.clip = clip;
			instance.bgMusic.Play();
			instance.bgMusic.time = currentTime;
		}
		/* source.Stop();
		source.clip = clip;
		source.Play();
		source.time = currentTime;
 */
	}
}
