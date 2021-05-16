using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

interface ICoffe {
    Color GetColor();
    float GetPrice();
}

class Coffe : ICoffe {
    public Color GetColor() {
        return new Color(50 / 255.0f, 30 / 255.0f, 20 / 255.0f);
    }

    public float GetPrice() {
        return 2;
    }
}

class CoffeDecorator : ICoffe {
    private ICoffe coffe;
    public CoffeDecorator(ICoffe coffe) {
        this.coffe = coffe;
    }
    public virtual Color GetColor() {
        return coffe.GetColor();
    }

    public virtual  float GetPrice() {
        return coffe.GetPrice();
    }
}

class MilkDecorator : CoffeDecorator {
    public MilkDecorator(ICoffe coffe) : base(coffe){
        
    }

    public override Color GetColor() {
        Color milkColor = new Color(1,1,1);
        return (base.GetColor()+ base.GetColor() + base.GetColor() + milkColor)/4;
    }

    public override float GetPrice() {
        return base.GetPrice() + 0.5f;
    }
}

class ChocolateDecorator : CoffeDecorator {
    public ChocolateDecorator(ICoffe coffe) : base(coffe) {

    }

    public override Color GetColor() {
        Color milkColor = new Color(72 / 255.0f, 29 / 255.0f, 21 / 255.0f);

        return (base.GetColor() + base.GetColor() + base.GetColor() + milkColor)/4;
    }
    public override float GetPrice() {
        return base.GetPrice() + 1f;
    }
}

class CreamDecorator : CoffeDecorator {
    public CreamDecorator(ICoffe coffe) : base(coffe) {

    }

    public override Color GetColor() {
        Color milkColor = new Color(255 / 255.0f, 231 / 255.0f, 170 / 255.0f);
        return (base.GetColor() + base.GetColor() + base.GetColor() + milkColor)/4;
    }
    public override float GetPrice() {
        return base.GetPrice() + 0.75f;
    }
}

public class CoffeMachine : MonoBehaviour
{
    [SerializeField] private GameObject glass;
    [SerializeField] private GameObject glassSpawn;
    [SerializeField] private GameObject glassFollow;
    [SerializeField] private TextMeshProUGUI newCoffeButton;
    [SerializeField] private TextMeshProUGUI price;
    int coffestate = 0;
    GameObject spawnedGlass;
    ICoffe coffe;

    public void SetDecorator(int decoratorID) {
        if (coffe == null) {
            Makebasecoffe();
            newCoffeButton.text = "Get Glass";
        }
        if (coffestate <= 2) { 
            switch (decoratorID) {
                case 0:
                    coffe = new MilkDecorator(coffe);
                    UpdatePrice();
                    break;
                case 1:
                    coffe = new ChocolateDecorator(coffe);
                    UpdatePrice();
                    break;
                case 2:
                    coffe = new CreamDecorator(coffe);
                    UpdatePrice();
                    break;
                default:
                    break;
            }
        }
    }

    void Makebasecoffe() {
        coffe = new Coffe();
        UpdatePrice();
    }

    void UpdatePrice() { 
    price.text = coffe.GetPrice() + "$";
    }

    public void CallCurrentState() {
        if (coffe == null) {
            Makebasecoffe();
        }
        if (coffestate == 0) { 
        StartCoroutine(SpawnGlassCourutine());
            coffestate = 1;
        }
        if (coffestate == 2) {
            coffestate = 3;
            Color coffeColor = coffe.GetColor();
            StartCoroutine(FillGlassCourutine(coffeColor));
        }
        if(coffestate == 4) {
            ResetAll();

        }
    }

    private void ResetAll() {
        coffestate = 0;
        coffe = null;
        Destroy(spawnedGlass);
        price.text = "0.00$";
        newCoffeButton.text = "Plain Coffe";
    }

    private void Start() {
        ResetAll();
    }

    //visual erpresentation of glass spawning
    IEnumerator SpawnGlassCourutine() {
        float maxTime = 0.5f;
        float currentTime = 0;
        Vector3 spawnPoint = glassSpawn.transform.position;
        Vector3 followPoint = glassFollow.transform.position;
        spawnedGlass = Instantiate(glass);
        spawnedGlass.transform.position = spawnPoint;
        SpriteRenderer sr = spawnedGlass.GetComponent<SpriteRenderer>();
        Color c = sr.color;
        c.a = 0;
        sr.color = c;
        while (currentTime < maxTime) {
            currentTime += Time.deltaTime;
            c.a = currentTime/ maxTime;
            sr.color = c;
            yield return null;
        }
        maxTime = 0.5f;
        currentTime = 0;
        while (currentTime < maxTime) {
            currentTime += Time.deltaTime;
            spawnedGlass.transform.position = Vector3.Lerp(spawnPoint,followPoint, currentTime / maxTime);
            yield return null;
        }
        newCoffeButton.text = "Buy?";
        coffestate = 2;
        yield return null;
    }

    //visual erpresentation of coffe pouring
    IEnumerator FillGlassCourutine(Color color) {
        GameObject coffe = spawnedGlass.transform.GetChild(0).gameObject;
        float maxTime = 0.5f;
        float currentTime = 0;
        coffe.GetComponent<SpriteRenderer>().color = color;
        while (currentTime < maxTime) {
            currentTime += Time.deltaTime;
            coffe.transform.localScale = Vector3.Lerp(new Vector3(0.37f,0,1), new Vector3(0.37f, 0.5f, 1), currentTime / maxTime);
            yield return null;
        }
        newCoffeButton.text = "Drink!";
        coffestate = 4;
        yield return null;
    }
}
