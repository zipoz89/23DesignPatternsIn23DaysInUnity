using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGem : MonoBehaviour
{
    Item item;

    public void setItem(Item item) {
        this.item = item;
        this.GetComponent<SpriteRenderer>().sprite = item.itemSprite;
        Debug.Log(item.name);
        if (item is SwordItem) {
            SwordItem ti= (SwordItem)item;
            Debug.Log("Attack= "+ti.attack);
        }
        if (item is ShieldItem) {
            ShieldItem ti = (ShieldItem)item;
            Debug.Log("Attack= " + ti.defense);
        }
        foreach (KeyValuePair<ItemBonus, float> entry in item.bonuses) {
            Debug.Log("Additional "+entry.Key+"= " +entry.Value);
        }
    }
}
