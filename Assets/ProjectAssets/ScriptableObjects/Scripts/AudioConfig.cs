using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "ScriptableObjects/Audio/AudioConfig")]
public class AudioConfig : ScriptableObject
{
    [BoxGroup("Game Volume")]
    [SerializeField, Range(0.0001f, 1f), Tooltip("Volume for music")]
    private float musicVolume;

    [BoxGroup("Game Volume")]
    [SerializeField, Range(0.0001f, 1f), Tooltip("Volume for sound effects")]
    private float sfxVolume;

    [BoxGroup("Game Volume")]
    [SerializeField, Range(0.0001f, 1f), Tooltip("Master volume for all audio")]
    private float masterVolume;

    public float MusicVolume
    {
        get
        {
            return musicVolume;
        }
        set
        {
            musicVolume = value;
        }
    }
    public float SfxVolume
    {
        get
        {
            return sfxVolume;
        }
        set
        {
            sfxVolume = value;
        }
    }
    public float MasterVolume
    {
        get
        {
            return masterVolume;
        }
        set
        {
            masterVolume = value;
        }
    }
}
