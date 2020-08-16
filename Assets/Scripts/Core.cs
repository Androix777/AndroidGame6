using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Core : MonoBehaviour
{
    public List<DamageDealer> meleeDamage = new List<DamageDealer>();
    public List<DamageDealer> spawningDamage = new List<DamageDealer>();
    public List<Shooter> noCombatShooters = new List<Shooter>();
    public List<Shooter> combatShooters = new List<Shooter>();
    public List<Life> lifes = new List<Life>();

    
    [ContextMenu("AddComponents")]
    private void AddComponents()
    {
        meleeDamage.Clear();
        spawningDamage.Clear();
        noCombatShooters.Clear();
        combatShooters.Clear();
        lifes.Clear();

        foreach(Component component in GetAllComponents(GetAllGO(gameObject)))
        {
            if(component.GetType() == typeof(Life))
            {
                lifes.Add(component as Life);
            }
            else if (component.GetType() == typeof(Shooter))
            {
                noCombatShooters.Add(component as Shooter);
            }
            else if (component.GetType() == typeof(DamageDealer))
            {
                meleeDamage.Add(component as DamageDealer);
            }
        }

        foreach(Shooter shooter in noCombatShooters)
        {
            foreach(Component component in GetAllComponents(GetAllGO(shooter.projectile.gameObject)))
            {
                if(component.GetType() == typeof(DamageDealer))
                {
                    if(!combatShooters.Contains(shooter))
                    {
                        combatShooters.Add(shooter);
                    }
                    spawningDamage.Add(component as DamageDealer);
                }
            }
        }

        foreach(Shooter shooter in combatShooters)
        {
            noCombatShooters.Remove(shooter);
        }

        foreach(DamageDealer damageDealer in spawningDamage)
        {
            meleeDamage.Remove(damageDealer);
        }
    }

    private List<GameObject> GetAllGO(GameObject GO, bool noFirst = false)
    {
        List<GameObject> allGO = new List<GameObject>();
        if (!noFirst)
        {
            allGO.Add(GO);
        }
        foreach(Transform child in GO.transform)
        {
            allGO.AddRange(GetAllGO(child.gameObject));
        }
        return allGO;
    }

    private List<Component> GetAllComponents(List<GameObject> allGO)
    {
        List<Component> allComponents = new List<Component>();
        foreach (GameObject GO in allGO)
        {
            allComponents.AddRange(GO.GetComponents<Component>());
        }
        return allComponents;
    }
}
