using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer : MonoBehaviour
{
    public abstract void OnNotify(object value,NotificationType type);
}

public abstract class Subject : MonoBehaviour {
    private List<Observer> observers = new List<Observer>();

    public void RegisterObserver(Observer observer){
        observers.Add(observer);
    }
    public void Notify(object value, NotificationType type) {
        foreach (Observer o in observers) {
            o.OnNotify(value,type);

        }
    }

}


public enum NotificationType {
    TriggerDoorlikeObject
}