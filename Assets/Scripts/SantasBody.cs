using UnityEngine;
using System.Collections;

public class SantasBody : MonoBehaviour {
	
	void OnEnable() {
		rigidbody.AddForce(-transform.forward*300,ForceMode.Impulse);
	}

}
