using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private float ratation;


    public void CastFireball() {
        GameObject o = Instantiate(fireballPrefab);
        o.transform.position = this.transform.position;
        o.transform.rotation = Quaternion.Euler(Vector3.forward* ratation);
    }
}