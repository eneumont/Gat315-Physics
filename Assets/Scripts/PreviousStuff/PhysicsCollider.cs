using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour {
	[SerializeField] GameObject fx;
	string status;
	Vector3 contact;
	Vector3 normal;

	void OnCollisionEnter(Collision collision) {
		status = "collision enter: " + collision.gameObject.name;

		contact = collision.GetContact(0).point;
		normal = collision.GetContact(0).normal;

		Instantiate(fx, contact, Quaternion.LookRotation(normal));
	}

	void OnCollisionStay(Collision collision) {
		status = "collision stay: " + collision.gameObject.name;
	}

	void OnCollisionExit(Collision collision) {
		status = "";
	}

	void OnTriggerEnter(Collider other) {
		status = "trigger enter: " + other.name;
	}

	void OnTriggerStay(Collider other) {
		status = "trigger stay: " + other.name;
	}

	void OnTriggerExit(Collider other) {
		status = "";
	}

	void OnGUI() {
		GUI.skin.label.fontSize = 16;
		Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
		GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(contact, 0.1f);
		Gizmos.DrawLine(contact, contact + normal);
	}
}