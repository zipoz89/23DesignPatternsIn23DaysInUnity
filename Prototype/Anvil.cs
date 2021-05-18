using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private GameObject hammerObject;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private SteelType steelType = SteelType.Damascus;

    [SerializeField] private Color[] gemColors;

    [SerializeField]
    private float throwSpeed;
    private void Start() {
        //CreateSword();
    }

    private void Awake() {
        particles.Stop();
    }

    private void CreateSword() {
        GameObject o = Instantiate(swordPrefab);
        o.GetComponent<Weapon>().SetColors(gemColors[Random.Range(0, gemColors.Length)], steelType);
        o.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-1f,1f),1)* throwSpeed;
        o.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
        //float torque = Random.Range(0.2f,1f);
        //torque *= Random.Range(0, 2) < 1 ? 1 : -1;
        o.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-0.1f, 0.1f), ForceMode2D.Impulse);

    }


    private void Update() {
        if (Input.GetMouseButtonDown(0))
            hammerObject.GetComponent<Animator>().SetTrigger("Hit");

    }

    public void HammerHit() {
        steelType = Random.Range(0, 2) < 1 ? SteelType.Damascus : SteelType.Standard;
        CreateSword();
        particles.Clear();
        particles.Play();
    }
}
