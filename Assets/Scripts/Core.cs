using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class Core : MonoBehaviour
{
    public List<DamageDealer> meleeDamage = new List<DamageDealer>();
    public List<DamageDealer> rangeDamage = new List<DamageDealer>();
    public List<Shooter> shooters = new List<Shooter>();
    public List<Life> lifes = new List<Life>();
    [ContextMenu("AddComponents")]
    private void AddComponents()
    {
        meleeDamage.Clear();
        rangeDamage.Clear();
        shooters.Clear();
        lifes.Clear();
        foreach(Component component in GetAllComponents(GetAllGO(gameObject)))
        {
            if(component.GetType() == typeof(Life))
            {
                lifes.Add(component as Life);
            }
            else if (component.GetType() == typeof(Shooter))
            {
                shooters.Add(component as Shooter);
            }
            else if (component.GetType() == typeof(DamageDealer))
            {
                meleeDamage.Add(component as DamageDealer);
            }
        }
        foreach(DamageDealer damageDealer in meleeDamage)
        {
            foreach(Shooter shooter in shooters)
            {
                if(GameObject.ReferenceEquals(shooter.projectile, damageDealer.gameObject))
                {
                    rangeDamage.Add(damageDealer);
                    break;
                }
            }
        }
        foreach(DamageDealer damageDealer in rangeDamage)
        {
            meleeDamage.Remove(damageDealer);
        }
    }

    private List<GameObject> GetAllGO(GameObject GO)
    {
        List<GameObject> allGO = new List<GameObject>();
        allGO.Add(GO);
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
