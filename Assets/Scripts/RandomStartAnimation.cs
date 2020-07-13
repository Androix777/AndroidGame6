using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartAnimation : MonoBehaviour
{
    [SerializeField] float timeStart = 0;
    [SerializeField] float timeEnd = 2;
    [SerializeField] Animator animator;
    void Start()
    {
        animator.Play("Tentacle_part", 0, Random.Range(0f,2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
