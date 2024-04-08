using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {
    [SerializeField] Bird[] ammo;
    [SerializeField] Transform emission;
    [SerializeField] AudioSource audio;
	[SerializeField] float fireRate;

	[SerializeField] Image redSelectImg;
	[SerializeField] Image bluesSelectImg;
	[SerializeField] Image bombSelectImg;
	[SerializeField] Image chuckSelectImg;

	int toggle = 0;
	bool fireReady = true;

	void Start () {
		redSelectImg.color = new Color(255, 0, 0);
		bluesSelectImg.color = new Color(0, 0, 255);
		chuckSelectImg.color = new Color(255, 255, 0);
		bombSelectImg.color = new Color(61, 61, 61);
	}

	void Update() {
		if (fireReady && Input.GetMouseButtonDown(0) && ammo[toggle].ammo.value > 0) {
			Instantiate(ammo[toggle], emission.position, emission.rotation);
			fireReady = false;
			StartCoroutine(FireTimer(fireRate));
		}

		if (Input.GetKey(KeyCode.X)) {
			toggle++;
			if (toggle >= ammo.Length) toggle = 0;

			switch (toggle) { 
				case 0:
					redSelectImg.
					redSelectImg.color = new Color();
					bombSelectImg.color = new Color(61, 61, 61);
					break;
				case 1:
					bluesSelectImg.color = new Color();
					redSelectImg.color = new Color(255, 0, 0);
					break;
				case 2:
					chuckSelectImg.color = new Color();
					bluesSelectImg.color = new Color(0, 0, 255);
					break;
				case 3:
					bombSelectImg.color = new Color();
					chuckSelectImg.color = new Color(255, 255, 0);
					break;
			}
		}
	}

	IEnumerator FireTimer(float time) {
		yield return new WaitForSeconds(time);
		fireReady = true;
	}
}