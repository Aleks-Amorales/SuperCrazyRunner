using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GroundCheker groundCheker;

	public float jumpSpeed = 10;
	private bool isGrounded = false;

	void Update(){
		if(groundCheker.isGrounded && Input.GetKeyDown(KeyCode.Space)){
			rigidbody.AddForce(0,jumpSpeed ,0,ForceMode.Impulse);
		}
	}


}
