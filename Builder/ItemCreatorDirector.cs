using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class ItemCreatorDirector : MonoBehaviour
{
    ItemBuilder itemBuilder;
    Item builtItem;
    [SerializeField] private ItemGem itemGem;

    [SerializeField] private Sprite swordSprite;
    [SerializeField] private Sprite shieldSprite;
    [SerializeField] private string[] randomWords;
    

    private void BuildRandomSword() {
        itemBuilder = new SwordBuilder();
        itemBuilder.setName("Sword of " + randomWords[UnityEngine.Random.Range(0, randomWords.Length)]);
        itemBuilder.setMainStat(UnityEngine.Random.Range(20f,70f));
        itemBuilder.setSprite(swordSprite);
        itemBuilder.setBonus(GetRandomBonus(), UnityEngine.Random.Range(5f, 20f));
        builtItem = itemBuilder.GetItem();
    }

    private void BuildRandomShield() {
        itemBuilder = new ShieldBuilder();
        itemBuilder.setName("Shield of " + randomWords[UnityEngine.Random.Range(0, randomWords.Length)]);
        itemBuilder.setMainStat(UnityEngine.Random.Range(50f, 100f));
        itemBuilder.setSprite(shieldSprite);
        itemBuilder.setBonus(GetRandomBonus(), UnityEngine.Random.Range(5f, 20f));
        builtItem = itemBuilder.GetItem();
    }

    public void SpawnRandomItem() {
        if (UnityEngine.Random.Range(0f, 1f) < 0.5f)
            BuildRandomShield();
        else BuildRandomSword();

        itemGem.setItem(builtItem);
    }



    private ItemBonus GetRandomBonus() {
        int enumCount = Enum.GetNames(typeof(ItemBonus)).Length;
        int randomBonusIndex = (int)UnityEngine.Random.Range(0f, enumCount);
        return (ItemBonus)randomBonusIndex;
    }
}
