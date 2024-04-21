using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Manages sound playback throughout the game, including music and sound effects.
/// </summary>
public class SoundManager : MonoBehaviour
{
    /// <summary>
    /// AudioSource used for background music playback.
    /// </summary>
    public AudioSource musicSource;

    /// <summary>
    /// AudioSource used for playing sound effects.
    /// </summary>
    public AudioSource soundEffectSource;

    /// <summary>
    /// An array of AudioClip, each representing a different music track for various game scenes.
    /// </summary>
    public AudioClip[] musicTracks;

    /// <summary>
    /// An array of AudioClip for different sound effects in the game.
    /// </summary>
    public AudioClip[] soundEffects;

    private static SoundManager instance = null;

    /// <summary>
    /// Singleton instance of the SoundManager to ensure it can be accessed globally without duplicates.
    /// </summary>
    public static SoundManager Instance => instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            musicSource.loop = false; // Ensures that the music loops continuously.
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Debug.Log(musicSource.isPlaying);
        StopMusic();
        PlayMusic(0);
        transform.DOMove(transform.position,1).SetLoops(-1).OnStepComplete(CheckIfIntroIsplaying);
    }
    

    void CheckIfIntroIsplaying()
    {
        if(musicSource.isPlaying == false)
        {
            StopMusic();
            PlayMusic(1);
            Debug.Log("New Music Playing");
            musicSource.loop = true;
        }
    }
    /// <summary>
    /// Plays a sound effect from the soundEffects array at the specified index.
    /// </summary>
    /// <param name="index">Index of the sound effect to play in the soundEffects array.</param>
    public void PlaySoundEffect(int index)
    {
        if (index >= 0 && index < soundEffects.Length)
        {
            soundEffectSource.PlayOneShot(soundEffects[index]);
        }
    }

    /// <summary>
    /// Plays background music from the musicTracks array at the specified index.
    /// If music is already playing, the function will not attempt to play another track.
    /// </summary>
    /// <param name="index">Index of the music track to play in the musicTracks array.</param>
    public void PlayMusic(int index)
    {
       
        if (index >= -1 && index < musicTracks.Length && !musicSource.isPlaying)
        {
            musicSource.clip = musicTracks[index];
            musicSource.Play();
            Debug.Log("Changes music to: " + index);
        }
    }

    /// <summary>
    /// Stops the currently playing music.
    /// </summary>
    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
           
        }
    }
    
    /// <summary>
    /// Sets the volume of the background music.
    /// </summary>
    /// <param name="volume">Volume level to set, ranging from 0.0 to 1.0.</param>
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
}