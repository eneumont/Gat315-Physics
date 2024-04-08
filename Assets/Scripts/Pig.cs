using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {
	[SerializeField] int points = 5000;
	[SerializeField] IntVariable score;
	[SerializeField] AudioSource audio;

	void OnCollisionEnter(Collision collision) {
		if (collision.rigidbody.velocity.magnitude > 0.3 || collision.rigidbody.angularVelocity.magnitude > 0.3) {
			audio.Play();

			if (collision.gameObject.GetComponent<Bird>()) score.value += points;
			if (collision.gameObject.GetComponent<Building>()) score.value += points / 2;

			Destroy(gameObject, 2);
		}
	}
}