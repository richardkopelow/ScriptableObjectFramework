﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioManager", menuName = "Scriptable Objects/Systems/Audio/Audio Manager")]
public class AudioManager : ScriptableObject
{
    public ScriptedAudioSource AudioSourcePrefab;

    private List<ScriptedAudioSource> pool;

    private void OnEnable()
    {
        pool = new List<ScriptedAudioSource>();
    }

    private void OnDisable()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            Destroy(pool[i]);
        }
    }

    public virtual ScriptedAudioSource Play(AudioAsset audioAsset)
    {
        ScriptedAudioSource swimmer = null;
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].IsPlaying)
            {
                swimmer = pool[i];
                break;
            }
        }
        if (swimmer == null)
        {
            swimmer = Instantiate(AudioSourcePrefab);
            swimmer.OnDestorying += OnDestroying;
            pool.Add(swimmer);
        }
        swimmer.name = "PooledAudio-" + audioAsset.name;
        swimmer.Play(audioAsset);
        return swimmer;
    }

    public virtual ScriptedAudioSource Play(AudioClip audioClip)
    {
        AudioAsset asset = ScriptableObject.CreateInstance<AudioAsset>();
        asset.Clip = audioClip;
        return Play(asset);
    }

    private void OnDestroying(ScriptedAudioSource audioSource)
    {
        pool.Remove(audioSource);
    }
}
