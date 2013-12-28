using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GroundCheker groundCheker;
	public Road roadManager;
	public float gravity = 30;
	public float jumpHeight = 2;
	public float slideSpeed = 5;
	public float jumpSpeed = 10;

	private float turnIndex = 0;
	private GameManager gameManager;
	private Animator animator;
	void Start(){
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		animator = GetComponentInChildren<Animator>();
	}
	void Awake(){
		rigidbody.useGravity = false;
	}

	void FixedUpdate(){
		if(groundCheker.isGrounded && Input.GetButton("Jump")){
			rigidbody.velocity = new Vector3(0,CalculateJumpVerticalSpeed(),0);
		}
		MoveTo(Input.GetAxisRaw("Horizontal"));
		rigidbody.AddForce(new Vector3(0,-gravity*rigidbody.mass,0));
		
	}

	void MoveTo(float directionIndex){

		Vector3 targetVelocity = Vector3.Cross(transform.forward, directionIndex*Vector3.up); 		
		targetVelocity *= -slideSpeed;
		Vector3 velocityChange = (targetVelocity - rigidbody.velocity);
		velocityChange.y = 0;
		
		rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
	}

	void Update(){
		Turn(-(int)Input.GetAxisRaw("Horizontal"));
		animator.SetFloat("Vertical Speed", rigidbody.velocity.y);
		animator.SetFloat("Horizontal Speed", Input.GetAxisRaw("Horizontal"));
	}

	void Turn(int turnDirectionIndex){
		if((turnIndex == 0) || (turnDirectionIndex == 0)){
			return;
		}
		else if (turnIndex != turnDirectionIndex){
			gameManager.GameOver();
			return;
		}
		else{
			transform.forward = Vector3.Cross(transform.forward,turnDirectionIndex*Vector3.up);
			roadManager.SetMovingDirection(transform.forward);
			transform.position = Vector3.up;
			turnIndex = 0;
		}

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Segment"){
			turnIndex = other.GetComponent<Segment>().direction;
		}
		if (other.tag == "Obstacle"){
			gameManager.GameOver();
		}
	}

	float CalculateJumpVerticalSpeed () {
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}

	


}
