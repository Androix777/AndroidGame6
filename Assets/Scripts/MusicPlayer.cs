using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicPlayer : MonoBehaviour
{
    
    [Serializable]public struct MusicClip
    {
        public AudioClip music;
        public StageGame stage;
    }
    public List<MusicClip> MusicList;
    float musicVolume = 0;
    [SerializeField]LevelManager manager;

    [SerializeField] AudioSource audioComponent;
    [SerializeField] float ticks = 10;
    void Start()
    {
        if (manager != null) 
            manager.stageChanged.AddListener(ChangeMusic);
        
        audioComponent.clip = FindMusic(StageGame.Battle).music;
        audioComponent.Play();
        ChangeMusic();

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
        
        switch(manager.Stage)
        {
            case(StageGame.Battle):
            yield return StartCoroutine(MusicVolumeChange(false));
            break;
            case(StageGame.BossBattle):
            yield return StartCoroutine(MusicVolumeChange(false));
            audioComponent.clip = FindMusic(manager.Stage).music;
            audioComponent.Play();
            break;
            
            case (StageGame.EndBossBattle):
            yield return StartCoroutine(MusicVolumeChange(true));
            audioComponent.clip = FindMusic(StageGame.Battle).music;
            audioComponent.Play();
            yield return StartCoroutine(MusicVolumeChange(false));
            break;

            case(StageGame.Peace):
            yield return StartCoroutine(MusicVolumeChange(true));
            break;
        }
        ChangeVolume();
    }

    IEnumerator MusicVolumeChange(bool down)
    {
        for (int i = 0; (musicVolume > 0.1 || !down) && (musicVolume < 1 || down); i++)
        {
            musicVolume = down? musicVolume - i / ticks: musicVolume + i / ticks;
            musicVolume = Mathf.Clamp(musicVolume,0.1f,1f);
            ChangeVolume();
            yield return new WaitForSeconds(0.1f);
        }
    }


    MusicClip FindMusic(StageGame stage)
    {
        List<MusicClip> clips = new List<MusicClip>();
        clips.AddRange(MusicList.ToArray());
        while (clips.Count > 0)
        {
            MusicClip clip = clips[UnityEngine.Random.Range(0,clips.Count)];
            if (clip.stage == stage)
                return clip;
            else clips.Remove(clip);
        }
        return new MusicClip();
    }
    void ChangeVolume()
    {
        if (audioComponent != null)
        {
            audioComponent.volume = SoundSystem.VolumeMusic * musicVolume;
        }
    }
}
