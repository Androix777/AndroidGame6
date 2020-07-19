﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public class Way
    {
        public Way(Text nameText, Text descriptionText, Button button)
        {
            this.nameText = nameText;
            this.descriptionText = descriptionText;
            this.button = button;
        }
        public Text nameText, descriptionText;
        public Button button;
    }
    private Way[] ways;
    

    public class LevelEvent
    {
        public LevelEvent(string name, EventDelegate eventDelegate)
        {
            this.name = name;
            this.eventDelegate = eventDelegate;
        }
        public string name;
        public string description = "test test test";
        public float probability; //на будущее
        public delegate void EventDelegate();
        public EventDelegate eventDelegate;
    }
    private LevelEvent[] LevelEvents;


    public Transform canvasWays;
    public MobSpawner mobSpawner;
    public GameObject hero;
    public string[] items;
    private int levelNum = 1; //на будущее

    void Start()
    {
        mobSpawner.levelEventEnd.AddListener(GenerateEvents);

        ways = new Way[canvasWays.childCount];
        int wayID = 0;
        foreach (Transform way in canvasWays)
        {
            ways[wayID] = new Way(way.Find("Name").GetComponent<Text>(), 
            way.Find("Description").GetComponent<Text>(), 
            way.Find("Button").GetComponent<Button>());
            wayID++;
        }

        LevelEvents = new LevelEvent[4];
        LevelEvents[0] = new LevelEvent("Battle", StartBattleEvent);
        LevelEvents[1] = new LevelEvent("Treasury", StartTreasuryEvent);
        LevelEvents[2] = new LevelEvent("Shop", StartShopEvent);
        LevelEvents[3] = new LevelEvent("Random", StartRandomEvent);

        GenerateEvents();
    }

    void Update()
    {
        
    }

    void GenerateEvents()
    {
        ShowCanvasWays(true);
        List<int> selectedEvents = new List<int>();
        int currentSelected;
        while(selectedEvents.Count < 3)
        {
            currentSelected = Random.Range(0,LevelEvents.Length);
            if (!selectedEvents.Contains(currentSelected))
            {
                selectedEvents.Add(currentSelected);
            }
        }

        int wayID = 0;
        foreach (int selectedEvent in selectedEvents)
        {
            ways[wayID].nameText.text = LevelEvents[selectedEvent].name;
            ways[wayID].descriptionText.text = LevelEvents[selectedEvent].description;
            ways[wayID].button.onClick.RemoveAllListeners();
            ways[wayID].button.onClick.AddListener(delegate{LevelEvents[selectedEvent].eventDelegate();});
            wayID++;
        }
    }

    public void ShowCanvasWays(bool b)
    {
        canvasWays.gameObject.SetActive(b);
    }

    public void ActivateItem(string itemName)
    {
        hero.AddComponent(System.Type.GetType(itemName));
        GenerateEvents();
    }

    void StartBattleEvent()
    {
        ShowCanvasWays(false);
        mobSpawner.StartWaves();
    }

    void StartTreasuryEvent()
    {
        List<int> selectedItems = new List<int>();
        int currentSelected;
        while(selectedItems.Count < 3)
        {
            currentSelected = Random.Range(0,items.Length);
            if (!selectedItems.Contains(currentSelected))
            {
                selectedItems.Add(currentSelected);
            }
        }

        int itemID = 0;
        foreach (int selectedItem in selectedItems)
        {
            ways[itemID].nameText.text = items[selectedItem];
            ways[itemID].descriptionText.text = ""; // пока так
            ways[itemID].button.onClick.RemoveAllListeners();
            ways[itemID].button.onClick.AddListener(delegate{ActivateItem(items[selectedItem]);});
            itemID++;
        }
    }

    void StartShopEvent()
    {

    }

    void StartRandomEvent()
    {
        
    }
}
