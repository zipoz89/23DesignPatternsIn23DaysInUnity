using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] BasicSword sword;
    [SerializeField] private Color damascusColor;
    [SerializeField] private Color standardColor;
    [SerializeField] int minDmg;
    [SerializeField] int maxDmg;

   

    private void Awake() {
        sword = new BasicSword(Random.Range(1,10), sword.gemCollor,sword.steelType);
    }

    private void Start() {

       
    }

    public void SetColors(Color gemColor, SteelType steelType) {
        sword.gemCollor = gemColor;
        sword.steelType = steelType;
        if(sword.steelType == SteelType.Damascus)
            this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = damascusColor;
        else
            this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = standardColor;
        this.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = sword.gemCollor;
    }

}
