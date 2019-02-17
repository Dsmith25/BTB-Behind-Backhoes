using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BG_Music_Manager : MonoBehaviour
{
	public List<AudioClip> SongList = new List<AudioClip>();
	public float bgVolume = .5f;
	public int curSong = 0;
	public int ranMin, ranMax;
	public bool PlayRandomly = false;
	public float pitch = 1f;
	public float StereoPan;
	
	void Start()
	{
		GetComponent<AudioSource>().volume = bgVolume;
		GetComponent<AudioSource>().pitch = pitch;
		ranMax = SongList.Count;
	}
	
	void Update()
	{
		if(PlayRandomly)
			PlayRandom();
		else
			Playlist();

		GetComponent<AudioSource>().volume = bgVolume;
		GetComponent<AudioSource> ().pitch = pitch;
		GetComponent<AudioSource> ().panStereo = StereoPan;
	}
	
	void PlayRandom()
	{
		if(!GetComponent<AudioSource>().isPlaying)
		{
			GetComponent<AudioSource>().clip = SongList[Random.Range(ranMin, ranMax)];
			GetComponent<AudioSource>().Play();
		}
	}

	void Playlist()
	{
		if(!GetComponent<AudioSource>().isPlaying)
		{
			if(curSong > SongList.Capacity)
			{
				curSong = 0;
			}
			else
			{
				curSong++;
			}
			GetComponent<AudioSource>().clip = SongList[curSong];
			GetComponent<AudioSource>().Play();
		}
	}
	
	void PlayRepeat(AudioClip Song)
	{
		GetComponent<AudioSource>().clip = Song;
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().Play();
	}
	
}