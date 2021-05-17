using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedievalVillager : MonoBehaviour,Villager
{
    string[] dialogs = new string[]{ "I ned to milk my cow!","Hey wanna buy some wheat?","Long live the king" };

    public void Talk() {
        Debug.Log("MedievalVillager: " + dialogs[Random.Range(0, dialogs.Length)]);
    }


}
