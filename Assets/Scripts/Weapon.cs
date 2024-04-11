using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {
    [SerializeField] GameObject[] ammo;
    [SerializeField] Transform emission;
    [SerializeField] AudioSource audio;
	[SerializeField] float fireRate;

	[SerializeField] Image redSelectImg;
	[SerializeField] Image bluesSelectImg;
	[SerializeField] Image bombSelectImg;
	[SerializeField] Image chuckSelectImg;
	[SerializeField] TMP_Text redTxt;
	[SerializeField] TMP_Text bluesTxt;
	[SerializeField] TMP_Text bombTxt;
	[SerializeField] TMP_Text chuckTxt;

	[SerializeField] VoidEvent startGameEvent;
	[SerializeField] VoidEvent winGameEvent;
	[SerializeField] VoidEvent loseGameEvent;

	int toggle = 0;
	bool fireReady = true;

	void OnEnable() {
		startGameEvent.Subscribe(StartGame);	
	}

	void Start () {
		redSelectImg.color = new Color(255, 0, 0);
		bluesSelectImg.color = new Color(0, 0, 255);
		chuckSelectImg.color = new Color(255, 255, 0);
		bombSelectImg.color = new Color(61, 61, 61);
		redTxt.text = "x " + ammo[0].GetComponent<Bird>().ammo.value;
		bluesTxt.text = "x " + ammo[1].GetComponent<Bird>().ammo.value;
		chuckTxt.text = "x " + ammo[2].GetComponent<Bird>().ammo.value;
		bombTxt.text = "x " + ammo[3].GetComponent<Bird>().ammo.value;
	}

	void Update() {
		if (fireReady && Input.GetMouseButtonDown(0) && ammo[toggle].GetComponent<Bird>().ammo.value > 0) {
			Instantiate(ammo[toggle], emission.position, emission.rotation);
			fireReady = false;

			ammo[toggle].GetComponent<Bird>().ammo.value--;
			redTxt.text = "x " + ammo[0].GetComponent<Bird>().ammo.value;
			bluesTxt.text = "x " + ammo[1].GetComponent<Bird>().ammo.value;
			chuckTxt.text = "x " + ammo[2].GetComponent<Bird>().ammo.value;
			bombTxt.text = "x " + ammo[3].GetComponent<Bird>().ammo.value;

			StartCoroutine(FireTimer(fireRate));
		}

		if (Input.GetKeyUp(KeyCode.X)) {
			toggle++;
			if (toggle >= ammo.Length) toggle = 0;

			switch (toggle) { 
				case 0:
					redSelectImg.color = new Color(165, 0, 255);
					bombSelectImg.color = new Color(61, 61, 61);
					break;
				case 1:
					bluesSelectImg.color = new Color(165, 0, 255);
					redSelectImg.color = new Color(255, 0, 0);
					break;
				case 2:
					chuckSelectImg.color = new Color(165, 0, 255);
					bluesSelectImg.color = new Color(0, 0, 255);
					break;
				case 3:
					bombSelectImg.color = new Color(165, 0, 255);
					chuckSelectImg.color = new Color(255, 255, 0);
					break;
			}
		}

		WinGame();
		LoseGame();
	}

	IEnumerator FireTimer(float time) {
		yield return new WaitForSeconds(time);
		fireReady = true;
	}

	void StartGame() {
		for (int i = 0; i < ammo.Length; i++) {
			ammo[i].GetComponent<Bird>().ammo.value = 0;
		}
		toggle = 0;
	}

	void WinGame() {
		GameObject[] pigs = new GameObject[10];
		GameObject piggy = null;

		for (int i = 0; i < pigs.Length; i++) {
			pigs[i] = GameObject.Find("Pig (" + i + ")");
			piggy = pigs[i];

			if (piggy != null) break;
		}

		if (piggy == null) { winGameEvent.RaiseEvent(); }
	}

	void LoseGame() {
		if (ammo[0].GetComponent<Bird>().ammo.value < 1 && ammo[1].GetComponent<Bird>().ammo.value < 1 &&
			ammo[2].GetComponent<Bird>().ammo.value < 1 && ammo[3].GetComponent<Bird>().ammo.value < 1)
		{
			loseGameEvent.RaiseEvent();
		}
	}
}