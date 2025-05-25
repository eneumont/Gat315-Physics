using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		print("trigger happended");
	}
}