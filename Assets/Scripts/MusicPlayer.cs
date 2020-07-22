using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField]AudioClip musicBattle;
    [SerializeField]AudioClip musicPeace;
    [SerializeField]AudioClip musicBossBattle;

    [SerializeField]LevelManager manager;

    [SerializeField] AudioSource audioComponent;
    [SerializeField] float ticks = 10;
    void Start()
    {
        if (manager != null) 
            manager.stageChanged.AddListener(ChangeMusic);
        SoundSystem.volumeMusicChanged.AddListener(ChangeVolume);
        ChangeVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeMusic()
    {
        if (audioComponent != null)
        {
            StartCoroutine(ChangeMusicSmooth());
        }
        
    }

    IEnumerator ChangeMusicSmooth()
    {
        for (int i = 0; i < ticks; i++)
        {
            audioComponent.volume = SoundSystem.VolumeMusic * i / ticks;
            yield return new WaitForSeconds(0.1f);
        }
        switch(manager.Stage)
        {
            case(StageGame.Battle):
            audioComponent.clip = musicBattle;
            break;
            case(StageGame.BossBattle):
            audioComponent.clip = musicBattle;
            break;
            case(StageGame.Peace):
            audioComponent.clip = musicBattle;
            break;
        }
        ChangeVolume();
    }

    void ChangeVolume()
    {
        if (audioComponent != null)
        {
            audioComponent.volume = SoundSystem.VolumeMusic;
        }
    }
}
