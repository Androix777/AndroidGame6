using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu]
public class BattleVariant: ScriptableObject, IShowable
{
    public string variantName;
    public string description;
    public float spawnRateMult = 1; 
    public float spawnRatePlus = 0; 
    public float waveNumberMult = 1;
    public int waveNumberPlus = 0;
    public float numOfSpawnsMult = 1;
    public int numOfSpawnsPlus = 0;
    public BattleType battleType;
    public float commonChance;
    public float uncommonChance;
    public float rareChance;
    public float epicChance;
    public float legendaryChance;

    public Rarity GetRevard()
    {
        System.Random rand = new System.Random();
        float[] allRarities = new float[] {commonChance, uncommonChance, rareChance, epicChance, legendaryChance};
        Rarity selectedRarity = Rarity.Common;

        double probSum = allRarities.Sum();
        double r = rand.NextDouble() * probSum;
        double sum = 0;
        int index = 0;
        foreach(float rarityProb in allRarities)
        {
            if(r <= (sum = sum + rarityProb))
            {
                selectedRarity = (Rarity)index;
            }
            index++;
        }
        return selectedRarity;
    }

    public List<Rarity> GetRevard(int n)
    {
        List<Rarity> selectedRarities = new List<Rarity>(); 

        for(int i = 0; i < n; i++)
        {
            selectedRarities.Add(GetRevard());
        }

        return selectedRarities;
    }

    public string GetName()
    {
        return variantName;
    }

    public string GetDescription()
    {
        return description;
    }
}