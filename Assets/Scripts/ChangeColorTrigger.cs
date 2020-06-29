using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ChangeColorTrigger : MonoBehaviour, ITrigger
{
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private MinMaxGradient gradient;
    private ColorOverLifetimeModule colorOverLifetime;
    [SerializeField] private MinMaxGradient gradientBack;
    [SerializeField] private bool backColor;
    [SerializeField] private bool modeOneGetColor;
    [SerializeField] private float time;

    private void Start()
    {
        colorOverLifetime = particle.colorOverLifetime;
        if (modeOneGetColor && backColor)
        {
            gradientBack = colorOverLifetime.color;
        }

    }
    private void Update()
    {
        gradient.mode = ParticleSystemGradientMode.Gradient;
    }

    public void ActivateEffect()
    {
        if (!modeOneGetColor && backColor)
        {
            gradientBack = colorOverLifetime.color;
        }
        colorOverLifetime.color = gradient;
        if (backColor) StartCoroutine(BackColor());
    }

    IEnumerator BackColor()
    {
        yield return new WaitForSeconds(time);
        colorOverLifetime.color = gradientBack;
    }
}
