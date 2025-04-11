using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundsManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip background; // Background music
    [SerializeField] private List<SoundEffect> soundEffects; // List of sound effects

    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform; // Reference to the player's position
    [SerializeField] private float maxDistance = 20f; // Maximum distance for audible sound

    private Dictionary<string, AudioClip> soundEffectDict;

    private void Start()
    {
        // Initialize the dictionary
        soundEffectDict = new Dictionary<string, AudioClip>();
        foreach (var effect in soundEffects)
        {
            if (!soundEffectDict.ContainsKey(effect.name))
            {
                soundEffectDict.Add(effect.name, effect.clip);
            }
        }

        // Start playing background music
        if (musicSource != null && background != null)
        {
            musicSource.clip = background;
            musicSource.loop = true; // Ensures continuous playback
            musicSource.Play();
        }
    }

    private void Update()
    {
        AdjustVolumeBasedOnDistance();
    }

    private void AdjustVolumeBasedOnDistance()
    {
        if (playerTransform != null && musicSource != null && SFXSource != null)
        {
            // Calculate distance between player and UISoundsManager
            float distance = Vector3.Distance(playerTransform.position, transform.position);

            // Adjust volume based on distance (normalize between 0 and 1)
            float volumeFactor = Mathf.Clamp01(1 - (distance / maxDistance));
            musicSource.volume = volumeFactor;
            SFXSource.volume = volumeFactor;
        }
    }

    public void PlaySFX(string effectName)
    {
        if (soundEffectDict.ContainsKey(effectName))
        {
            AudioClip clip = soundEffectDict[effectName];
            if (SFXSource != null && clip != null)
            {
                SFXSource.PlayOneShot(clip);
            }
        }
        else
        {
            Debug.LogWarning("Sound effect not found: " + effectName);
        }
    }
}

[System.Serializable]
public class SoundEffect
{
    public string name; // Unique name for the sound effect
    public AudioClip clip; // The actual sound clip
}