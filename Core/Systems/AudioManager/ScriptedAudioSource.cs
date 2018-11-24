using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ScriptedAudioSource : MonoBehaviour
{
    public AudioAsset Audio;
    public bool IsPlaying => audioSource.isPlaying;
    public bool Muted
    {
        get => audioSource.mute;
        set => audioSource.mute = value;
    }
    public event Action<ScriptedAudioSource> OnDestorying;

    private Transform trans;
    private AudioSource audioSource;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioAsset audio)
    {
        Audio = audio;
        Play();
    }

    public void Play()
    {
        trans.position = Audio.Position;
        audioSource.clip = Audio.Clip;
        audioSource.outputAudioMixerGroup = Audio.MixerGroup;
        audioSource.bypassEffects = Audio.BypassEffects;
        audioSource.bypassReverbZones = Audio.BypassReverbZone;
        audioSource.loop = Audio.Loop;
        audioSource.priority = Audio.Priority;
        audioSource.volume = Audio.Volume;
        audioSource.pitch = Audio.Pitch;
        audioSource.panStereo = Audio.StereoPan;
        audioSource.spatialBlend = Audio.SpatialBlend;
        audioSource.reverbZoneMix = Audio.ReverbZoneMix;
        audioSource.dopplerLevel = Audio.DopplerLevel;
        audioSource.spread = Audio.Spread;
        audioSource.rolloffMode = Audio.VolumeRolloff;
        audioSource.minDistance = Audio.MinDistance;
        audioSource.maxDistance = Audio.MaxDitance;

        audioSource.Play();
    }

    private void OnDestroy()
    {
        OnDestorying?.Invoke(this);
    }
}
