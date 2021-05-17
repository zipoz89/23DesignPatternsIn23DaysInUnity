using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertVillageFactory : MonoBehaviour
{

    [SerializeField] private float spawnRadius;

    [SerializeField] private GameObject animalPrefab;
    [SerializeField] private GameObject housePrefab;
    [SerializeField] private GameObject villagerPrefab;

    public Animal SpawnAnimal() {
        GameObject o = Instantiate(animalPrefab);
        float x = Random.Range(this.transform.position.x - spawnRadius, this.transform.position.x + spawnRadius);
        float y = 0;
        float z = Random.Range(this.transform.position.z - spawnRadius, this.transform.position.z + spawnRadius);
        o.transform.position = new Vector3(x, y, z);
        o.transform.parent = transform;
        return o.GetComponent<Animal>();
    }

    public House SpawnHouse() {
        GameObject o = Instantiate(housePrefab);
        float x = Random.Range(this.transform.position.x - spawnRadius, this.transform.position.x + spawnRadius);
        float y = 0;
        float z = Random.Range(this.transform.position.z - spawnRadius, this.transform.position.z + spawnRadius);
        o.transform.position = new Vector3(x, y, z);
        o.transform.parent = transform;
        return o.GetComponent<House>();
    }

    public Villager SpawnVillager() {
        GameObject o = Instantiate(villagerPrefab);
        float x = Random.Range(this.transform.position.x - spawnRadius, this.transform.position.x + spawnRadius);
        float y = 0;
        float z = Random.Range(this.transform.position.z - spawnRadius, this.transform.position.z + spawnRadius);
        o.transform.position = new Vector3(x, y, z);
        o.transform.parent = transform;
        return o.GetComponent<Villager>();
    }



    void Start() {
            Villager villager = SpawnVillager();
            villager.Talk();

            House house = SpawnHouse();
            house.SwitchLights();

            Animal animal = SpawnAnimal();
            animal.Eat();
    }
}
