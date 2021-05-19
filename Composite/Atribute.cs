using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAtribute
{
    protected float baseValue;
    protected float modifier;


    public BasicAtribute(float atributeValue, float multiplier = 0) {
        this.baseValue = atributeValue;
        this.modifier = multiplier;
    }
    public virtual float GetModifiedValue() {
        if (modifier != 0)
            return baseValue *= modifier;
        else return baseValue;
    }

    public float BaseValue() { return baseValue; }
    public void SetBaseValue(float value) { baseValue = value; }
    public float Modifier() { return modifier; }

    public void SetModifier(float value) { modifier = value; }
}

public class TemporaryBonus : BasicAtribute {
    public TemporaryBonus(float atributeValue, float multiplier) : base(atributeValue, multiplier) { }

}

public class FinalBonus : BasicAtribute {
    public FinalBonus(float atributeValue, float multiplier) : base(atributeValue, multiplier) { }

}

public class Atribute : BasicAtribute {
    Dictionary<string,TemporaryBonus> temporaryBonuses = new Dictionary<string, TemporaryBonus>();
    List<FinalBonus> finalBonuses = new List<FinalBonus>();

    private float finalValue;

    public Atribute(float value) : base(value) {
        finalValue = value;

    }

    public void addTemporaryBonus(string id,TemporaryBonus bonus) {
        temporaryBonuses.Add(id,bonus);
    }

    public void removeTemporaryBonus(string id, TemporaryBonus bonus) {
        temporaryBonuses.Remove(id);
    }

    public void addFianlBonus(FinalBonus bonus) {
        finalBonuses.Add(bonus);
    }

    public override float GetModifiedValue() {
        finalValue = BaseValue();

        float rawBonusValue = 0;
        float rawBonusMultiplier = 0;

        foreach (KeyValuePair<string, TemporaryBonus> t in temporaryBonuses) {
            rawBonusValue += t.Value.BaseValue();
            rawBonusMultiplier += t.Value.Modifier();
        }

        finalValue += rawBonusValue;
        finalValue *= (1 + rawBonusMultiplier);

        float finalBonusValue =0;
        float finalBonusMultiplier = 0;

        foreach (FinalBonus f in finalBonuses) {
            finalBonusValue += f.BaseValue();
            finalBonusMultiplier += f.Modifier();
        }

        finalValue += finalBonusValue;
        finalValue *= (1 + finalBonusMultiplier);

        return finalValue;
    }
}