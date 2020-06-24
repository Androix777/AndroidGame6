using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public static class Functions
{
    public static async void DestroyWithDeathEffects(GameObject destroyedObject, float time = 0, DeathCause deathCause = DeathCause.All)
    {
        await Task.Delay((int)(time * 1000));
        if(destroyedObject != null)
        {
            IDeathEffect[] deathEffect = destroyedObject.GetComponents<IDeathEffect>();
            foreach (IDeathEffect effect in deathEffect)
            {
                if(effect.AllowedDeathCause == DeathCause.All || effect.AllowedDeathCause == deathCause)
                {
                    effect.ActivateEffect();
                }
            }
            Object.Destroy(destroyedObject);
        }
    }
}