using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Animal {
    void Eat();
}

public interface Villager {
    void Talk();
}

public interface House {
    void SwitchLights();
}


public interface VillageFactory
{
    House SpawnHouse();
    Villager SpawnVillager();
    Animal SpawnAnimal();
}
