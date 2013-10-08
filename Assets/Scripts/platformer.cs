using UnityEngine;
using System.Collections;

public class platformer : MonoBehaviour {
	
	public float jumpSpeed = 7f;
	bool isGrounded = false;
	public int maxAirJumpCount = 1;
	int airJumpCount = 0;
	public float playerSpeed = 5f;
	public float rotateSpeed = 5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		
	}
	

	void FixedUpdate () {
		
		Ray rightRay = new Ray(transform.position, Vector3.left);
		Ray leftRay = new Ray(transform.position, Vector3.right);
		
		//doublejump stuff
		
		Ray rayDown1 = new Ray(transform.position,Vector3.down);
		//check if you're on the ground
		if(Physics.Raycast (rayDown1,0.5f)){
			isGrounded = true;
			airJumpCount = maxAirJumpCount;
		}else{
			isGrounded = false;
		}
		
		//if on the ground, can jump once, airJumpCount is put to 1 (i.e. you can jump once in the air)
		if(Input.GetKeyDown (KeyCode.Space)){
			if(Physics.Raycast (rightRay, 0.5f) == true){
				rigidbody.AddForce (Vector3.up*jumpSpeed/2, ForceMode.VelocityChange);
				rigidbody.AddForce (Vector3.right*jumpSpeed/2, ForceMode.VelocityChange);
			}
			if(Physics.Raycast (leftRay, 0.5f) == true){
				rigidbody.AddForce (Vector3.up*jumpSpeed/2, ForceMode.VelocityChange);
				rigidbody.AddForce (Vector3.left*jumpSpeed/2, ForceMode.VelocityChange);
			}
			if(isGrounded){
				rigidbody.AddForce (Vector3.up*jumpSpeed, ForceMode.Impulse);
			 //if in the air, you can jump again, and airJumpCount is put to 0
			}else if(airJumpCount > 0){
					airJumpCount -= 1;
					rigidbody.AddForce (Vector3.up*jumpSpeed, ForceMode.Impulse);
			}
		}
		
			//move side to side 
		if(Input.GetKey (KeyCode.A)){
			transform.Translate(-playerSpeed*Time.deltaTime,0f,0f);			
		}
		
		if(Input.GetKey (KeyCode.D)){
			transform.Translate(playerSpeed*Time.deltaTime,0f,0f);
		}
		
	}
	
}
