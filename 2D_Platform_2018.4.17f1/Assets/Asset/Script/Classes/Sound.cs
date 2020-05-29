using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [SerializeField]
    private AudioSource Source;
    [SerializeField]
    private AudioClip Clip;
    [SerializeField]
    private string Name;
    [SerializeField]
    [Range(0, 1)]
    private float Volume;
    [SerializeField]
    private bool PlayOnAwake;
    [SerializeField]
    private bool Loop;

    public void SetSource(AudioSource source) { Source = source; }
    public void SetClip(AudioClip clip) { Clip = clip; }
    public void SetVolume(float volume) { Volume= volume; }
    public void SetPlayOnAwake(bool playOnAwake) { PlayOnAwake = playOnAwake; }
    public void SetLoop(bool loop) { Loop = loop; }


    public AudioSource GetAudioSource() { return Source; }   
    public AudioClip GetClip() { return Clip; }
    public string GetName() { return Name; }
    public float GetVolume() { return Volume; }
    public bool GetPlayOnAwake() { return PlayOnAwake; }
}
