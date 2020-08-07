using UnityEditor;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;
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
    private StageGame _stage;
    public UnityEvent stageChanged = new UnityEvent();
    public StageGame Stage
    {
        get { return _stage; }
        set
        {
            _stage = value;
            stageChanged.Invoke();
        }
    }

    public Transform canvasWays;
    public MobSpawner mobSpawner;
    public GameObject hero;
    public ItemManager itemManager;
    public BattleVariantManager battleVariantManager;
    private GameFloor gameFloor;
    private int roomNum;
    private List<Item> selectedItems;
    private List<BattleVariant> selectedBattleVariants;
    private bool nowBattle = true;


    void Start()
    {
        gameFloor = GameFloor.FirstLevel;
        roomNum = 1;
        mobSpawner.battleEnd.AddListener(delegate{ShowCanvasWays(true);});
        ways = new Way[canvasWays.childCount];
        int wayID = 0, wayID2;
        foreach (Transform way in canvasWays)
        {
            ways[wayID] = new Way(way.Find("Name").GetComponent<Text>(), 
            way.Find("Description").GetComponent<Text>(), 
            way.Find("Button").GetComponent<Button>());
            wayID2 = wayID;
            ways[wayID].button.onClick.AddListener(delegate{PressButton(wayID2);});
            wayID++;
        }

        GenerateEvents();
    }

    private void GenerateEvents()
    {
        switch(gameFloor)
        {
            case GameFloor.FirstLevel:
                switch(roomNum)
                {
                    case 1:
                        ShowBattleWays(battleVariantManager.GetBattleVariants(BattleType.Normal));
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
        roomNum++;
    }

    public void ShowCanvasWays(bool b)
    {
        canvasWays.gameObject.SetActive(b);
    }
    public void ShowBattleWays(List<BattleVariant> battleVariants)
    {
        selectedBattleVariants = battleVariants;
        AddWays(selectedBattleVariants);
    }

    void StartBattle(BattleVariant battleVariant)
    {
        Stage = StageGame.Battle;
        hero.SetActive(true);
        ShowCanvasWays(false);
        mobSpawner.StartWaves(battleVariant);
    }

    public void ActivateItem(Item item)
    {
        hero.SetActive(true);
        hero.AddComponent(item.component.GetClass());
        GenerateEvents();
    }

    void PressButton(int index)
    {
        if(nowBattle)
        {
            selectedItems = itemManager.GetItems(selectedBattleVariants[index].GetRevard(3));
            AddWays(selectedItems, false);
            StartBattle(selectedBattleVariants[index]);
        }
        else
        {
            ActivateItem(selectedItems[index]);
            GenerateEvents();
        }
    }

    void AddWays(List<IShowable> ishowables, bool show = true)
    {
        for(int i = 0; i < ishowables.Count; i++)
        {
            ways[i].nameText.text = ishowables[i].GetName();
            ways[i].descriptionText.text = ishowables[i].GetDescription();
        }
        if(show)
        {
            ShowCanvasWays(true);
        }

        if(ishowables[0].GetType() == typeof(BattleVariant))
        {
            nowBattle = true;
        }
        else
        {
            nowBattle = false;
        }
    }
    void AddWays(List<Item> items, bool show = true)
    {
        AddWays(items.Cast<IShowable>().ToList(), show);
    }
    void AddWays(List<BattleVariant> battleVariants, bool show = true)
    {
        AddWays(battleVariants.Cast<IShowable>().ToList(), show);
    }
}
