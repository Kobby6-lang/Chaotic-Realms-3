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

    private void Awake()
    {
        soundEffectDict = new Dictionary<string, AudioClip>();
        foreach (var effect in soundEffects)
        {
            if (!soundEffectDict.ContainsKey(effect.name))
            {
                soundEffectDict.Add(effect.name, effect.clip);
            }
        }
    }
    private void Start()
    {
        // Set AudioSource to ignore AudioListener's global pause state
        if (musicSource != null)
        {
            musicSource.ignoreListenerPause = true;
        }
        if (SFXSource != null)
        {
            SFXSource.ignoreListenerPause = true;
        }

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
        if (soundEffectDict == null)
        {
            Debug.LogError("soundEffectDict is not initialized!");
            return;
        }

        if (SFXSource == null)
        {
            Debug.LogError("SFXSource is not assigned!");
            return;
        }

        if (soundEffectDict.ContainsKey(effectName))
        {
            AudioClip clip = soundEffectDict[effectName];
            if (clip != null)
            {
                SFXSource.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning("The AudioClip for " + effectName + " is null!");
            }
        }
        else
        {
            Debug.LogWarning("Sound effect not found: " + effectName);
        }
    }

    [System.Serializable]
    public class SoundEffect
    {
        public string name; // Unique name for the sound effect
        public AudioClip clip; // The actual sound clip
    }
}