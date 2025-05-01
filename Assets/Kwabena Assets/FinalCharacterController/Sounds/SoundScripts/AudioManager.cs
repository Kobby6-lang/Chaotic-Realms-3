using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI slider functionality

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] public AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip landing;

    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform; // Reference to the player's position
    [SerializeField] private List<Transform> trapSoundLocations; // Positions of trap sound emitters
    [SerializeField] private List<AudioSource> trapAudioSources; // Audio sources for trap sounds

    [Header("Trap Settings")]
    [SerializeField] private float maxDistance = 10f; // Maximum distance for audible sound

    [Header("UI")]
    [SerializeField] private Slider trapVolumeSlider; // Slider for controlling trap sounds volume

    private void Start()
    {
        // Play background music
        PlayBackgroundMusic(background);

        // Ensure slider is initialized and dynamically updates trap volume
        if (trapVolumeSlider != null)
        {
            trapVolumeSlider.value = 1f; // Default to full volume
            trapVolumeSlider.onValueChanged.AddListener(UpdateTrapSoundsVolumeFromSlider);
        }
    }

    private void Update()
    {
        UpdateTrapSoundsVolume(); // Update trap sounds based on player proximity and slider value
    }

    private void UpdateTrapSoundsVolume()
    {
        if (playerTransform == null || trapSoundLocations == null || trapAudioSources == null) return;

        for (int i = 0; i < trapSoundLocations.Count; i++)
        {
            if (i >= trapAudioSources.Count) break;

            // Calculate distance between player and trap sound emitter
            float distance = Vector3.Distance(playerTransform.position, trapSoundLocations[i].position);

            // Volume factor based on distance (1 = close, 0 = far)
            float distanceFactor = Mathf.Clamp01(1 - (distance / maxDistance)); // Proximity-based volume

            // Get slider volume (1 = full volume, 0 = muted)
            float sliderVolume = trapVolumeSlider != null ? trapVolumeSlider.value : 1f;

            // Final combined volume
            trapAudioSources[i].volume = distanceFactor * sliderVolume;

            // Play or stop sound based on distance threshold
            if (distance > maxDistance && trapAudioSources[i].isPlaying)
            {
                trapAudioSources[i].Stop(); // Stop sound if beyond range
            }
            else if (distance <= maxDistance && !trapAudioSources[i].isPlaying)
            {
                trapAudioSources[i].Play(); // Resume sound if within range
            }
        }
    }

    private void UpdateTrapSoundsVolumeFromSlider(float sliderValue)
    {
        // Immediately update trap sounds volume based on slider changes
        if (trapAudioSources == null) return;

        foreach (AudioSource trapAudioSource in trapAudioSources)
        {
            // Directly adjust volume based on slider value
            trapAudioSource.volume = sliderValue;
        }
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
}