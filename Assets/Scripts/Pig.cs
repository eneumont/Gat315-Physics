using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {
	[SerializeField] int points = 100;
	[SerializeField] AudioSource audio;

	void OnCollisionEnter(Collision collision) {
		if (collision.rigidbody.velocity.magnitude > 0.3 || collision.rigidbody.angularVelocity.magnitude > 0.3) {
			audio.Play();
			Destroy(gameObject, 2);
		}
	}
}