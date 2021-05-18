using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SwordPrototype  {
    public int attack;


    protected SwordPrototype(int attack) {
        this.attack = attack;
    }

    public abstract SwordPrototype Clone();
}

[System.Serializable]
public class BasicSword : SwordPrototype {
    public Color gemCollor;
    public SteelType steelType;


    public BasicSword(int attack, Color gemCollor, SteelType steelType) : base(attack) {
        this.gemCollor = gemCollor;
        this.steelType = steelType;
    }

    public override SwordPrototype Clone() {
        return new BasicSword(attack, gemCollor,steelType);
    }
}
public enum SteelType {
    Standard,
    Damascus
}