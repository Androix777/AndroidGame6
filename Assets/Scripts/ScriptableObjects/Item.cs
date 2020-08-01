using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class Item : ScriptableObject 
{
    public MonoScript component;
    public string itemName;
    public string description;
    public Archetype archetype;
    public Rarity rarity;

}