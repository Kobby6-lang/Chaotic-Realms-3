using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip death;
    public AudioClip slicing;
    public AudioClip swinging;
    public AudioClip landing;
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
   
    public void PlaySFX(AudioClip clip) 
    {
        SFXSource.PlayOneShot(clip);
    }
}
