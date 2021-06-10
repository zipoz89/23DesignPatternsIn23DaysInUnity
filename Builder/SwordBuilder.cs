using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBuilder : ItemBuilder {

    private SwordItem sword;

    public SwordBuilder() {
        sword = new SwordItem();
    }

    public Item GetItem() {
        return sword;
    }

    public void setBonus(ItemBonus bonus, float stat) {
        sword.bonuses.Add(bonus,stat);
    }

    public void setMainStat(float stat) {
        sword.attack = stat;
    }

    public void setName(string name) {
        sword.name = name;
    }

    public void setSprite(Sprite sprite) {
        sword.itemSprite = sprite;
    }
}
