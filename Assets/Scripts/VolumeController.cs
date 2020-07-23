using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField][Range(0,1)]private float volume = 1;
    [SerializeField][Range(0,1)]private float volumeMusic = 1;
    [SerializeField][Range(0,1)]private float volumeSounds = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SoundSystem.Volume != volume) SoundSystem.Volume = volume;
        if (SoundSystem.VolumeMusic != volumeMusic) SoundSystem.VolumeMusic = volumeMusic;
        if (SoundSystem.VolumeSounds != volumeSounds) SoundSystem.VolumeSounds = volumeSounds;
    }
}
