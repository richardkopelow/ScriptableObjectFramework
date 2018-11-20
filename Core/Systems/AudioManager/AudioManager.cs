using System.Collections;
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

    public virtual void Play(AudioAsset audioAsset, out ScriptedAudioSource audioSource)
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
        audioSource = swimmer;
    }
    public virtual void Play(AudioAsset audioAsset)
    {
        ScriptedAudioSource audioSource = null;
        Play(audioAsset, out audioSource);
    }

    public virtual void Play(AudioClip audioClip, out ScriptedAudioSource audioSource)
    {
        AudioAsset asset = ScriptableObject.CreateInstance<AudioAsset>();
        asset.Clip = audioClip;
        Play(asset, out audioSource);
    }

    public virtual void Play(AudioClip audioClip)
    {
        ScriptedAudioSource audioSource;
        Play(audioClip, out audioSource);
    }

    private void OnDestroying(ScriptedAudioSource audioSource)
    {
        pool.Remove(audioSource);
    }
}
