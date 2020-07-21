using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour, ITrigger
{
    [SerializeField] AudioSource audioComponent;

    [SerializeField] float volumeBase = 1;
    [SerializeField] AudioType type;

    void Start()
    {
        if (audioComponent != null)
            volumeBase = audioComponent.volume;
        
        switch(type)
        {
            case AudioType.All:
                SoundSystem.volumeChanged.AddListener(ChangeVolume);
            break;
            case AudioType.Sounds:
                SoundSystem.volumeSoundsChanged.AddListener(ChangeVolume);
            break;
            case AudioType.Music:
                SoundSystem.volumeMusicChanged.AddListener(ChangeVolume);
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ChangeVolume()
    {
        float volume = 0;
        switch(type)
        {
            case AudioType.All:
                volume = SoundSystem.Volume;
            break;
            case AudioType.Sounds:
                volume = SoundSystem.VolumeSounds;
            break;
            case AudioType.Music:
                volume = SoundSystem.VolumeMusic;
            break;
        }
        audioComponent.volume = volumeBase * volume;
    }
    public void ActivateEffect()
    {
        if (audioComponent != null)
            audioComponent.Play();
    }
}
