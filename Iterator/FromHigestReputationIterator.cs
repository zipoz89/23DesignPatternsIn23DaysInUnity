using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromHigestReputationIterator : Iterator {
    private MerchantsCollection collection;

    private int position = -1;

    public FromHigestReputationIterator(MerchantsCollection collection) {
        this.collection = collection;
        GetFirst();
    }

    public override object Current() {
        return this.collection.merchantsCollection[position];
    }

    public override bool MoveNext() {
        int currentValue = collection.merchantsCollection[position].GetComponent<Merchant>().reputation;
        int firstSmallerThan = int.MinValue;
        int index = 0 ;
        bool isThereNext = false;
        for (int i = 0; i < collection.merchantsCollection.Count; i++) {
            int checking = collection.merchantsCollection[i].GetComponent<Merchant>().reputation;
            if (checking < currentValue && checking > firstSmallerThan) {
                firstSmallerThan = checking;
                index = i;
                isThereNext = true;
            }
        }
        
        if(!isThereNext)
            GetFirst();
        else
            position = index;

        return isThereNext;

    }

    public override void Reset() {
        GetFirst();
    }

    private void GetFirst() {
        int max = int.MinValue;
        int maxIndex = 0;
        for (int i = 0; i < collection.merchantsCollection.Count; i++) {
            int checking = collection.merchantsCollection[i].GetComponent<Merchant>().reputation;
            if (checking > max) {
                max = checking;
                maxIndex = i;
            }
        }
        position = maxIndex;
    }
}
