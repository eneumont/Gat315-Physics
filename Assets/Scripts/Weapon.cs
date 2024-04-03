using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] GameObject[] ammo;
    [SerializeField] Transform emission;
    [SerializeField] AudioSource audio;

    int toggle = 0;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            audio.Play();
            Instantiate(ammo[toggle], emission.position, emission.rotation);
        }
    }
}
