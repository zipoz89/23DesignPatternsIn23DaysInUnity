using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atribute
{
    protected float atributeBaseValue;
    protected float multiplier;


    public Atribute(float atributeValue, float multiplier = 0) {
        this.atributeBaseValue = atributeValue;
        this.multiplier = multiplier;
    }

    public float BaseValue() { return atributeBaseValue; }
    public void SetValue(float value) { atributeBaseValue = value; }
    public float BaseMultipier() { return multiplier; }

    public void SetMultipier(float value) { multiplier = value; }
}

public class RawBonus : Atribute {
    public RawBonus(float atributeValue, float multiplier) : base(atributeValue, multiplier) { }

}

public class FinalBonus : Atribute {
    public FinalBonus(float atributeValue, float multiplier) : base(atributeValue, multiplier) { }

}

public class FinalAtribute : Atribute {
    List<RawBonus> rawBonuses = new List<RawBonus>();
    List<FinalBonus> finalBonuses = new List<FinalBonus>();

    private float finalValue;

    public FinalAtribute(float value) : base(value) {
        finalValue = value;

    }

    public void addRawBonus(RawBonus bonus) {
        rawBonuses.Add(bonus);
    }

    public void addFianlBonus(FinalBonus bonus) {
        finalBonuses.Add(bonus);
    }

    public float calculateValue() {
        finalValue = BaseValue();
        float rawBonusValue = 0;
        float rawBonusMultiplier = 0;

        foreach (RawBonus r in rawBonuses) {
            rawBonusValue += r.BaseValue();
            rawBonusMultiplier += r.BaseMultipier();
        }

        finalValue += rawBonusValue;
        finalValue *= (1 + rawBonusMultiplier);

        float finalBonusValue =0;
        float finalBonusMultiplier = 0;

        foreach (FinalBonus f in finalBonuses) {
            finalBonusValue += f.BaseValue();
            finalBonusMultiplier += f.BaseMultipier();
        }

        finalValue += finalBonusValue;
        finalValue *= (1 + finalBonusMultiplier);

        return finalValue;
    }
}