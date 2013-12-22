using UnityEngine;
using System.Collections;

public class GroundCheker : MonoBehaviour {

	public bool isGrounded = false;

	void OnTriggerStay(){
		isGrounded = true;
	}
	void OnTriggerExit(){
		isGrounded = false;
	}
}
