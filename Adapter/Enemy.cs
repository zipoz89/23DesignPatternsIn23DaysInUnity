using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IEnemy {
    void Attack();
}

public class SpellCasterEnemy : IEnemy {
    SpellCaster spellCaster;


    public SpellCasterEnemy(SpellCaster spellCaster) {
        this.spellCaster = spellCaster;
    }

    public void Attack() {
        spellCaster.CastFireball();
    }
}


public class Enemy : MonoBehaviour {
    [SerializeField] private SpellCaster spellCaster;
    IEnemy enemy;

    private void Start() {
        enemy = new SpellCasterEnemy(spellCaster);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            enemy.Attack();
        }
    }
}
