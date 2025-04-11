using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip death;
    public List<AudioClip> trapSounds; // List for all trap sound effects

    private void Start()
    {
        PlayBackgroundMusic(background);
        SFXSource.ignoreListenerPause = true;
    }

    public void PlayBackgroundMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
    }

    public void PlayLoopingTrapSound(int trapIndex, AudioSource source = null)
    {
        if (source == null)
        {
            source = SFXSource;
            return;
        }
        if (trapSounds != null && trapIndex >= 0 && trapIndex < trapSounds.Count)
        {
            // Set the clip to the SFXSource and enable looping
            source.clip = trapSounds[trapIndex];
            source.loop = true;
            source.Play();
        }
        else
        {
            Debug.LogWarning("Invalid trap sound index or trapSounds list is not populated!");
        }
    }

    public void StopLoopingTrapSound(AudioSource source  = null)
    {
        if (source == null)
        {
            source = SFXSource;
        }
        // Stop the looping sound and disable looping
        source.Stop();
        source.loop = false;
    }

    public void PlayTrapSound(int trapIndex)
    {
        if (trapSounds != null && trapIndex >= 0 && trapIndex < trapSounds.Count)
        {
            // Play the sound corresponding to the specific trap
            PlaySFX(trapSounds[trapIndex]);
        }
    }
}