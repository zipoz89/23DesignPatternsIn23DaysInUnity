using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MediatorEvents { 
    Attack,
    MoveLeft,
    MoveRight,
    StopMovement
}

public interface Mediator 
{
    
    void Notify(object sender, MediatorEvents ev);
}


public class UiSkeletonMediator : MonoBehaviour, Mediator {

    [SerializeField] private List<Skeleton> skeletons;

    public UiSkeletonMediator(List<Skeleton> skeletons) {
        
    }

    public void Notify(object sender, MediatorEvents ev) {
        switch (ev) {
            case MediatorEvents.Attack:
                NotifyAttack();
                break;
            case MediatorEvents.MoveLeft:
                NotifyMove(MovingDirection.Left);
                break;
            case MediatorEvents.MoveRight:
                NotifyMove(MovingDirection.Rigt);
                break;
            case MediatorEvents.StopMovement:
                NotifyStoppedMovement();
                break;
            default:
                break;
        }
    }

    private void NotifyStoppedMovement() {
        foreach (Skeleton s in skeletons) {
            s.StopMovement();
        }
    }

    private void NotifyMove(MovingDirection movingDirection) {
        foreach (Skeleton s in skeletons) {
            s.Move(movingDirection);
        }
    }

    private void NotifyAttack() {
        foreach (Skeleton s in skeletons) {
            s.Attack();
        }
    }
}
