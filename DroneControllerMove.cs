using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
/* DroneControllerMove script modified from script found in Unity3D scripting API (ChracterController.Move page) 
 * -Removed gravity
 * -Added strafing and UpDown(y-axis) to axes, creating variables for use (v,s,z,h)
*/
public class DroneControllerMove : MonoBehaviour {

	public float speed = 1.0F;
	public float rotateSpeed = 1.0f;
	private float v;
	private float h;
	private float z;
	private float s;
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 move = Vector3.zero;

	private CharacterController controller;



	void Start()
	{
		controller = GetComponent<CharacterController> ();
	}

	void Update() {

		v = Input.GetAxis ("Vertical");
		s = Input.GetAxis ("Strafe");
		z = Input.GetAxis ("Updown");
		h = Input.GetAxis ("Horizontal");

		transform.Rotate (0, h * rotateSpeed, 0); //rotates drone
		moveDirection = new Vector3 (s, z, v); // creates vector3(left/right, up/down, forward/backward) with movement out from axes
		moveDirection = transform.TransformDirection (moveDirection); //sets facing direction of drone
		moveDirection *= speed; //increases speed of drone by speed variable

		move = moveDirection * Time.deltaTime; //smoothes drone movement with update time
		controller.Move (move); //moves drone


	}






}
