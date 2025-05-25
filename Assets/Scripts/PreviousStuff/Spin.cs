using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
    [SerializeField] Rigidbody rb;

    void Start () { 
        rb = GetComponent<Rigidbody>(); 
    }

    void Update() {
		rb.AddTorque(Vector3.up);
	}
}