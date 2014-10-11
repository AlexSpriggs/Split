using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public float speed, gravity, jump;
	private Vector3 movement;
	protected CharacterController controller = null;
	protected OVRCameraController CameraController = null;
	private float 	YRotation 	 = 0.0f;
	private Quaternion OrientationOffset = Quaternion.identity;	
	// Use this for initialization
	void Start () {
		movement = Vector3.zero;
		controller = gameObject.GetComponent<CharacterController>();

		OVRCameraController[] CameraControllers;
		CameraControllers = gameObject.GetComponentsInChildren<OVRCameraController>();
		
		if(CameraControllers.Length == 0)
			Debug.LogWarning("OVRPlayerController: No OVRCameraController attached.");
		else if (CameraControllers.Length > 1)
			Debug.LogWarning("OVRPlayerController: More then 1 OVRCameraController attached.");
		else
			CameraController = CameraControllers[0];	
	}
	
	// Update is called once per frame
	void Update () {

		if(controller.isGrounded){
		movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		movement = this.transform.TransformDirection(movement);
		movement *= speed * Time.deltaTime;

//			if(Input.GetKeyDown("Jump") && controller.isGrounded)
//			movement.y = jump * Time.deltaTime;



		movement.y -= gravity * Time.deltaTime;

		}
		movement.y -= gravity * Time.deltaTime;
		controller.Move(movement);

		
		float rightAxisX = 
			OVRGamepadController.GPC_GetAxis((int)OVRGamepadController.Axis.RightXAxis);
		
		// Rotate
		YRotation += rightAxisX; //* rotateInfluence;    
		
		// Update cameras direction and rotation
		SetCameras();
		this.transform.rotation = CameraController.transform.rotation;

	
	}

	public void SetCameras()
	{
		if(CameraController != null)
		{
			// Make sure to set the initial direction of the camera 
			// to match the game player direction
			CameraController.SetOrientationOffset(OrientationOffset);
			CameraController.SetYRotation(YRotation);
		}
	}
}
