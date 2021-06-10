using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ItemBuilder
{
    void setName(string name);
    void setSprite(Sprite sprite);
    void setMainStat(float stat);
    void setBonus(ItemBonus bonus,float stat);

    Item GetItem();
}
