using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuilder : ItemBuilder
{
    private ShieldItem shield;

    public ShieldBuilder() {
        shield = new ShieldItem();
    }

    public Item GetItem() {
        return shield;
    }

    public void setBonus(ItemBonus bonus, float stat) {
        shield.bonuses.Add(bonus, stat);
    }

    public void setMainStat(float stat) {
        shield.defense = stat;
    }

    public void setName(string name) {
        shield.name = name;
    }

    public void setSprite(Sprite sprite) {
        shield.itemSprite = sprite;
    }

}
