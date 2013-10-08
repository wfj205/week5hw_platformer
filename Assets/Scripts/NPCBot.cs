using UnityEngine;
using System.Collections;

public class NPCBot : MonoBehaviour {
	
	public float rayForwardDistance = 5f;
	public float rayRightDistance = 2f;
	public float rayLeftDistance = 2f;
	public float playerSpeed = 2f;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		
		Ray rayForward = new Ray(transform.position,transform.forward*2);
		
		//check to see if there's something in front of it
		if(Physics.Raycast (rayForward, rayForwardDistance)){
			float randomTurn = Random.Range (0,10);
			if(randomTurn < 5){
				//turn right
				transform.Rotate (0f,90f,0f);
			}else{
				//turn left
				transform.Rotate (0f,-90f,0f);
			}
		}
	}
	
	void FixedUpdate(){
		rigidbody.AddRelativeForce (Vector3.forward*playerSpeed);
		
		Ray rayRight = new Ray(transform.position,transform.right*2);
		Ray rayLeft = new Ray(transform.position,-transform.right*2);
		
		if(Physics.Raycast (rayRight,rayRightDistance)){
			rigidbody.AddRelativeForce (Vector3.left*playerSpeed);
		}
		
		if(Physics.Raycast (rayLeft,rayLeftDistance)){
			rigidbody.AddRelativeForce (Vector3.right*playerSpeed);
		}
		
	}
}
