using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class Item : ScriptableObject, IShowable
{
    public MonoScript component;
    public string itemName;
    public string description;
    public Archetype archetype;
    public Rarity rarity;
    
    public string GetName()
    {
        return itemName;
    }

    public string GetDescription()
    {
        return description;
    }

}