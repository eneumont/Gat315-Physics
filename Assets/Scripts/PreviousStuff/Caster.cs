using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour {
    public enum eType { 
        Ray, 
        Sphere, 
        Box
    }

    [SerializeField] eType type = eType.Ray;
    [SerializeField] float size = 1f;
    [SerializeField] float distance = 2f;
    [SerializeField] LayerMask mask = Physics.AllLayers;

    RaycastHit[] hits;

    void Update() {
		switch (type) {
			case eType.Ray:
                hits = Physics.RaycastAll(transform.position, transform.forward, distance, mask);
				break;
			case eType.Sphere:
				hits = Physics.SphereCastAll(transform.position, size * 0.5f, transform.forward, distance, mask);
				break;
			case eType.Box:
				hits = Physics.BoxCastAll(transform.position, Vector3.one * size * 0.5f, transform.forward, transform.rotation, distance, mask);
				break;
		}
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.blue;

		switch (type) {
			case eType.Ray:
				Gizmos.DrawRay(transform.position, transform.forward * distance);
				break;
			case eType.Sphere:
				Gizmos.DrawRay(transform.position, transform.forward * distance);
				Gizmos.DrawWireSphere(transform.position + transform.forward * distance, size * 0.5f);
				break;
			case eType.Box:
				Gizmos.DrawRay(transform.position, transform.forward * distance);
				Gizmos.DrawWireCube(transform.position + transform.forward * distance, Vector3.one * size);
				break;
		}

		if (hits != null) {
			Gizmos.color = Color.red;
			foreach (var hit in hits) {
				Gizmos.DrawWireCube(hit.collider.transform.position, hit.collider.bounds.size);
			}
		}
	}
}
