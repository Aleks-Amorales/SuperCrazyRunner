using UnityEngine;
using System.Collections;

public class GroundCheker : MonoBehaviour {

	public bool isGrounded = false;
	void OnTriggerEnter(){
		isGrounded = true;
	}

	void OnTriggerExit(){
		isGrounded = false;
	}
}
