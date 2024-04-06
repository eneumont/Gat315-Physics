using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bird : MonoBehaviour {
	enum BirdType {
		Red,
		Chuck,
		Blues, 
		Bomb
	}

	[SerializeField] float speed = 1;
	[SerializeField] float lifespan = 0;
	[SerializeField] BirdType type = BirdType.Red;
	Rigidbody rb;
	bool ability = true;
	GameObject Bluesd;
	public int ammo;

	void Start() {
		if (lifespan > 0) Destroy(gameObject, lifespan);
		rb = GetComponent<Rigidbody>();

		rb.AddRelativeForce(transform.rotation * Vector3.forward * speed, ForceMode.VelocityChange);
	}

	void Update() {
		switch (type) {
			case BirdType.Chuck:
				if (Input.GetKey(KeyCode.Z) && ability == true) {
					speed *= 4; 
					ability = false;
				}

				break;
			case BirdType.Blues:
				if (Input.GetKey(KeyCode.Z) && ability == true) {
					Instantiate(Bluesd, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
					Instantiate(Bluesd, transform.position + new Vector3(-0.5f, -0.5f, 0), transform.rotation);
					Instantiate(Bluesd, transform.position + new Vector3(0.5f, -0.5f, 0), transform.rotation);
					
					ability = false; 
				}

				break;
			case BirdType.Bomb:
				if (Input.GetKey(KeyCode.Z) && ability == true) {
					
					
					ability = false;
				}

				break;
		}
	}
}