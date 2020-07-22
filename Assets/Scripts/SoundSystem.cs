using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class SoundSystem
{
    private static float volume = 1;
    private static float volumeMusic = 1;
    private static float volumeSounds = 1;

    public static UnityEvent volumeChanged = new UnityEvent();
    public static UnityEvent volumeMusicChanged = new UnityEvent();
    public static UnityEvent volumeSoundsChanged = new UnityEvent();
    public static float Volume
    {
        get { return volume; }
        set
        {
            volume = value;
            volumeChanged.Invoke();
        }
    }

    public static float VolumeMusic
    {
        get { return volumeMusic; }
        set
        {
            volumeMusic = value;
            volumeMusicChanged.Invoke();
        }
    }

    public static float VolumeSounds
    {
        get { return volumeSounds; }
        set
        {
            volumeSounds = value;
            volumeSoundsChanged.Invoke();
        }
    }
}
