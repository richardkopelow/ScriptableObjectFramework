using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ScriptedAudioSource : MonoBehaviour
{
    public bool IsPlaying => audioSource.isPlaying;

    private Transform trans;
    private AudioSource audioSource;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioAsset audio)
    {
        trans.position = audio.Position;
        audioSource.clip = audio.Clip;
        audioSource.outputAudioMixerGroup = audio.MixerGroup;
        audioSource.bypassEffects = audio.BypassEffects;
        audioSource.bypassReverbZones = audio.BypassReverbZone;
        audioSource.loop = audio.Loop;
        audioSource.priority = audio.Priority;
        audioSource.volume = audio.Volume;
        audioSource.pitch = audio.Pitch;
        audioSource.panStereo = audio.StereoPan;
        audioSource.spatialBlend = audio.SpatialBlend;
        audioSource.reverbZoneMix = audio.ReverbZoneMix;

        audioSource.Play();
    }
}
