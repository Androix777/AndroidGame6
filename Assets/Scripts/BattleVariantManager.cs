using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleVariantManager : MonoBehaviour
{
    public BattleVariant[] battleVariants;
    
    public List<BattleVariant> GetBattleVariants(BattleType battleType = BattleType.Any)
    {
        System.Random rnd = new System.Random();
        List<BattleVariant> selectedVariants = new List<BattleVariant>();
        List<BattleVariant> rightTypeVariants = new List<BattleVariant>();
        List<BattleVariant> allVariants = new List<BattleVariant>(battleVariants);

        if(battleType != BattleType.Any)
        {
            foreach(BattleVariant battleVariant in allVariants)
            {
                if (battleVariant.battleType == battleType)
                {
                    rightTypeVariants.Add(battleVariant);
                }
            }
        }
        else
        {
            rightTypeVariants = allVariants;
        }

        int variantNum;
        while(selectedVariants.Count < 3)
        {
            variantNum = rnd.Next(rightTypeVariants.Count);
            selectedVariants.Add(rightTypeVariants[variantNum]);
            rightTypeVariants.RemoveAt(variantNum);
        }
        return selectedVariants;
    }
}
