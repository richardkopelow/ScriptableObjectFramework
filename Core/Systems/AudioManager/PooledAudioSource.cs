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
            mutableAudio = Instantiate(_audio);
        }
    }

    private Transform trans;
    private AudioAsset mutableAudio;

    private void Awake()
    {
        trans = GetComponent<Transform>();
        Audio = _audio;
    }

    public void Play()
    {
        mutableAudio.Position = trans.position;
        AudioManager.Play(mutableAudio);
    }
}
