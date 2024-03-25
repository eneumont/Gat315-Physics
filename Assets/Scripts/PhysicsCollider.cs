using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour {
	string status;

	void OnCollisionEnter(Collision collision) {
		status = "collision enter: " + collision.gameObject.name;
	}

	void OnCollisionStay(Collision collision) {
		
	}

	void OnCollisionExit(Collision collision) {
		status = "";
	}

	void OnTriggerEnter(Collider other) {
		status = "trigger enter: " + other.name;
	}

	void OnTriggerStay(Collider other) {
		
	}

	void OnTriggerExit(Collider other) {
		status = "";
	}

	void OnGUI() {
		GUI.skin.label.fontSize = 16;
		Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
		GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
	}
}