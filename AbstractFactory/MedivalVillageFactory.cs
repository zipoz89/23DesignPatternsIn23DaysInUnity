using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedivalVillageFactory : MonoBehaviour, VillageFactory
    {

    [SerializeField] private float spawnRadius;
    [SerializeField] private int villagersToSpawn;
    [SerializeField] private int housesToSpawn;
    [SerializeField] private int AnimalsToSpawn;

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



    void Start()
    {
        for (int i = 0; i < villagersToSpawn; i++) {
            Villager villager = SpawnVillager();
            villager.Talk();
        }

        for (int i = 0; i < housesToSpawn; i++) {
            House house = SpawnHouse();
            house.SwitchLights();
        }

        for (int i = 0; i < AnimalsToSpawn; i++) {
            Animal animal = SpawnAnimal();
            animal.Eat();
        }
    }



}
