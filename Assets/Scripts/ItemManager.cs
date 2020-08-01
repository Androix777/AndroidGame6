using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
    public Item[] items;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public List<Item> GetItems()
    {
        System.Random rnd = new System.Random();
        List<Item> selectedItems = new List<Item>();
        List<Item> allItems = new List<Item>(items);
        int itemNum;
        while(selectedItems.Count < 3)
        {
            itemNum = rnd.Next(allItems.Count);
            selectedItems.Add(allItems[itemNum]);
            allItems.RemoveAt(itemNum);
        }
        return selectedItems;
    }
}
