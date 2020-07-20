using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour, ITrigger
{
    [SerializeField] AudioSource audioComponent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateEffect()
    {
        if (audioComponent != null)
            audioComponent.Play();
    }
}
