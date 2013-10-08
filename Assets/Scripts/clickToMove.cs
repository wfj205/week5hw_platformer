using UnityEngine;
using System.Collections;

public class clickToMove : MonoBehaviour {
	
	bool isRaycast = false;
	public float playerSpeed = 5f;
	Vector3 destination = new Vector3();
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update(){
		
	}

	void FixedUpdate () {
		
		//Vector3 stoppingDistance = destination * 0.5;
		
		//if(Vector3.Distance (transform,destination) > stoppingDistance){
		//	rigidbody.AddRelativeForce (destination);
		//}
		
		Vector3 direction = Vector3.Normalize (destination - transform.position);
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit = new RaycastHit();
		
		if(Physics.Raycast(ray,out rayHit,10000f)){
			isRaycast = true;
		}
		
		if(Input.GetMouseButtonDown(0)){
			if(isRaycast){
				destination = rayHit.point;
				Vector3 stoppingDistance = destination * 0.5f;
				if(Vector3.Distance (transform.position,destination) > Vector3.Distance (stoppingDistance,destination)){
					rigidbody.AddForce (direction*playerSpeed);
				}
			}
		}
	}
}
