using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	[SerializeField] IntVariable score;
	[SerializeField] AudioSource audio;

	Rigidbody rb;
	int points;
	int health;

	public enum buildingType { 
		Glass,
		Wood,
		Stone
	}
	[SerializeField] buildingType type;

	void Start() {
		rb = GetComponent<Rigidbody>();

		switch (type) {
			case buildingType.Glass:
				points = 250;
				health = 25;
				break;
			case buildingType.Wood:
				points = 500;
				health = 50;
				break;
			case buildingType.Stone:
				points = 1000;
				health = 100;
				break;
		}
	}

	void Update() {
		if (health <= 0) {
			Destroy(gameObject);
		}	
	}

	void OnCollisionEnter(Collision collision) {
		if (rb.velocity.magnitude > 1 || rb.angularVelocity.magnitude > 1) {
			audio.Play();

			if (collision.gameObject.GetComponent<Bird>()) {
				switch (collision.gameObject.GetComponent<Bird>().type) {
					case Bird.BirdType.Red:
						health -= 50;
						break;
					case Bird.BirdType.Chuck:
						health -= 75;
						break;
					case Bird.BirdType.Blues:
						health -= 25;
						break;
					case Bird.BirdType.Bomb:
						health -= 100;
						break;
				}

				score.value += points;
			}

			if (collision.gameObject.GetComponent<Building>()) {
				switch (collision.gameObject.GetComponent<Building>().type) {
					case buildingType.Glass:
						health -= 15;
						break;
					case buildingType.Wood:
						health -= 30;
						break;
					case buildingType.Stone:
						health -= 50;
						break;
				}

				score.value += points / 2;
			}
		}
	}
}