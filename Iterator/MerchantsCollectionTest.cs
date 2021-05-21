using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MerchantsCollectionTest : MonoBehaviour
{
    public MerchantsCollection collection = new MerchantsCollection();
    FromHigestReputationIterator iterator;
    public TextMeshProUGUI reputationDisplay;
    public GameObject cameraObject;

    private void Start() {
        iterator = (FromHigestReputationIterator)collection.GetEnumerator();
        MoveVirtualCamera();
    }

    public void GoNext() {
        iterator.MoveNext();
        MoveVirtualCamera();
    }

    public void Reset() {
        iterator.Reset();
        MoveVirtualCamera();
    }

    public void MoveVirtualCamera() {
        GameObject o = (GameObject)iterator.Current();
        cameraObject.transform.position = new Vector3(o.transform.position.x, cameraObject.transform.position.y, -100);
        reputationDisplay.text = "Reputation: " + o.GetComponent<Merchant>().reputation;
    }
}
