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