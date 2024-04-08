using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	[SerializeField] int points = 100;
	[SerializeField] int heath = 100;
	[SerializeField] AudioSource audio;

	Rigidbody rb;
	bool destroyed = false;

	public enum buildingType { 
		Glass,
		Wood,
		Stone
	}
	[SerializeField] buildingType type;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision collision) {
		if (rb.velocity.magnitude > 2 || rb.angularVelocity.magnitude > 2) {
			audio.Play();
		}
	}

	void OnTriggerStay(Collider other) {
		if (!destroyed && other.CompareTag("Kill") &&
			rb.velocity.magnitude == 0 &&
			rb.angularVelocity.magnitude == 0)
		{
			destroyed = true;
			print(points);
			Destroy(gameObject, 1);
		}
	}
}