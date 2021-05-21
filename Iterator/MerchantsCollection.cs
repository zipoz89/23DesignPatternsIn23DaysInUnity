using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MerchantsCollection : Collection {
    public List<GameObject> merchantsCollection = new List<GameObject>();

    public override IEnumerator GetEnumerator() {
        return new FromHigestReputationIterator(this);
    }

}
