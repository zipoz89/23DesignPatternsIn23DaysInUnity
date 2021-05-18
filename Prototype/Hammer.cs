using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private Anvil anvil;
    public void HammerHit() {
        anvil.HammerHit();
    }
}
