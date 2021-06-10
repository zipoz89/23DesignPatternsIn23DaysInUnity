using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ItemBonus{
    Attack,
    AttackSpeed,
    Defense
}

public class Item
{
    public string name;
    public Sprite itemSprite;
    public Dictionary<ItemBonus, float> bonuses = new Dictionary<ItemBonus, float>();

}


public class SwordItem : Item{
    public float attack;
}

public class ShieldItem : Item {
    public float defense;
}