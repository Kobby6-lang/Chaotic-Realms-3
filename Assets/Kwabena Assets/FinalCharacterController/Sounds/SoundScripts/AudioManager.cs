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
    public AudioClip slicing;
    public AudioClip swinging;
    public AudioClip landing;
    public List<AudioClip> trapSounds; // List for all trap sound effects

    private void Start()
    {
        PlayBackgroundMusic(background);
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

    public void PlayLoopingTrapSound(int trapIndex)
    {
        if (trapSounds != null && trapIndex >= 0 && trapIndex < trapSounds.Count)
        {
            // Set the clip to the SFXSource and enable looping
            SFXSource.clip = trapSounds[trapIndex];
            SFXSource.loop = true;
            SFXSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid trap sound index or trapSounds list is not populated!");
        }
    }

    public void StopLoopingTrapSound()
    {
        // Stop the looping sound and disable looping
        SFXSource.Stop();
        SFXSource.loop = false;
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