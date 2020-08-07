using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
    public Item[] items;
    public Item defaultItem;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public List<Item> GetItems(List<Rarity> rarities)
    {
        System.Random rnd = new System.Random();
        List<Item> selectedItems = new List<Item>();
        List<Item> correctItems = new List<Item>();
        List<Item> allItems = new List<Item>(items);

        foreach(Rarity rarity in rarities)
        {
            correctItems.Clear();
            foreach(Item item in allItems)
            {
                if (item.rarity == rarity)
                {
                    correctItems.Add(item);
                }
            }
            foreach(Item item in selectedItems)
            {
                correctItems.Remove(item);
            }
            if(correctItems.Count > 0)
            {
                selectedItems.Add(correctItems[correctItems.Count]);
            }
            else
            {
                selectedItems.Add(defaultItem);
            }
        }
        return selectedItems;
    }
}
