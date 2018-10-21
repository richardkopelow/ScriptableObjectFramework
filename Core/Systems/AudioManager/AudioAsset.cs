using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "NewAudioAsset", menuName = "Scriptable Objects/Systems/Audio/Audio Asset")]
public class AudioAsset : ScriptableObject
{
    public AudioClip Clip;
    public Vector3 Position;
    public AudioMixerGroup MixerGroup;
    public bool BypassEffects;
    public bool BypassReverbZone;
    public bool Loop;
    [Range(0,256)]
    public int Priority=128;
    [Range(0,1)]
    public float Volume = 1;
    [Range(-3,3)]
    public float Pitch = 1;
    [Range(-1, 1)]
    public float StereoPan = 0;
    [Range(0,1)]
    public float SpatialBlend = 0;
    [Range(0, 1.1f)]
    public float ReverbZoneMix;
}
