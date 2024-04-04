using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] GameObject[] ammo;
    [SerializeField] Transform emission;
    [SerializeField] AudioSource audio;
	[SerializeField] float fireRate;

	int toggle = 0;
	bool fireReady = true;

	void Update() {
		if (fireReady && Input.GetMouseButtonDown(0)) {
			Instantiate(ammo[toggle], emission.position, emission.rotation);
			fireReady = false;
			StartCoroutine(FireTimer(fireRate));
		}
	}

	IEnumerator FireTimer(float time) {
		yield return new WaitForSeconds(time);
		fireReady = true;
	}
}