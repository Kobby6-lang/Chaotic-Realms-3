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

    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform; // Reference to the player's position
    [SerializeField] private List<Transform> trapSoundLocations; // Positions of trap sound emitters
    [SerializeField] private List<AudioSource> trapAudioSources; // Audio sources for trap sounds
    [SerializeField] private float maxDistance = 10f; // Maximum distance for audible sound

    private void Start()
    {
        PlayBackgroundMusic(background);
        SFXSource.ignoreListenerPause = true;
    }

    private void Update()
    {
        UpdateTrapSoundsVolume();
    }
    private void UpdateTrapSoundsVolume()
    {
        if (playerTransform == null || trapSoundLocations == null || trapAudioSources == null) return;

        for (int i = 0; i < trapSoundLocations.Count; i++)
        {
            if (i >= trapAudioSources.Count) break;

            float distance = Vector3.Distance(playerTransform.position, trapSoundLocations[i].position);
            float volumeFactor = Mathf.Clamp01(10 - (distance / maxDistance));
            float minVolume = 0.1f;

            trapAudioSources[i].volume = Mathf.Max(volumeFactor, minVolume);

            if (distance > maxDistance && trapAudioSources[i].isPlaying)
            {
                trapAudioSources[i].Stop(); // Stop sound if beyond threshold
            }
            else if (distance <= maxDistance && !trapAudioSources[i].isPlaying)
            {
                trapAudioSources[i].Play(); // Resume sound if within range
            }
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

    public void PlayLoopingTrapSound(int trapIndex, AudioSource source = null)
    {
        if (source == null)
        {
            source = SFXSource;
        }
        else
        {
            Debug.LogWarning("Invalid trap sound index or trapSounds list is not populated!");
        }
    }

    public void StopLoopingTrapSound(AudioSource source = null)
    {
        if (source == null)
        {
            source = SFXSource;
        }
        // Stop the looping sound and disable looping
        source.Stop();
        source.loop = false;
    }
}