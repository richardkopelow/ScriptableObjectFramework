using UnityEngine;

public class PooledAudioSource : MonoBehaviour
{
    public AudioManager AudioManager;
    [SerializeField]
    private AudioAsset _audio;
    public AudioAsset Audio
    {
        get
        {
            return _audio;
        }
        set
        {
            _audio = value;
            if (_audio != null)
            {
                mutableAudio = Instantiate(_audio);
            }
        }
    }
    public bool PlayOnAwake;

    private Transform trans;
    private AudioAsset mutableAudio;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        Audio = _audio;
        if (PlayOnAwake && Audio != null)
        {
            Play();
        }
    }

    public void Play()
    {
        mutableAudio.Position = trans.position;
        AudioManager.Play(mutableAudio);
    }

    public void Play(AudioAsset audio)
    {
        AudioAsset tmpAudio = Instantiate(audio);
        AudioManager.Play(tmpAudio);
    }
}
