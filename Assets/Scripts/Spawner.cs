using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] GameObject spawnObject;
    [SerializeField] KeyCode key;

	void Update() {
		if (Input.GetKeyDown(key)) { 
			Instantiate(spawnObject, transform.position, transform.rotation);
		}	
	}
}