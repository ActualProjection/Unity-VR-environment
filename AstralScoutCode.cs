using UnityEngine;
using System.Collections;

public class AstralScoutCode {

	//Acnhors as they are named in OVRCameraRig Script, merely for reference in this script
	public Transform trackingSpace;
	public Transform trackerAnchor;
	public Transform rightEyeAnchor;
	public Transform leftEyeAnchor;
	public Transform centerEyeAnchor;

	//string for euler, merely for reference in this script
	string eulerRot;

	//Converts the floats given by eulers to ints, necessary for serialization to Arduino
	public string EulerFloatToInt (Vector3 eulerN)
	{
		int x;
		int y;
		int z;

		if ((eulerN.x % (Mathf.FloorToInt (eulerN.x))) < 0.5f) {
			x = Mathf.FloorToInt (eulerN.x);
		}
		else
		{
			x = Mathf.CeilToInt (eulerN.x);
		}
		if ((eulerN.y % (Mathf.FloorToInt (eulerN.y))) < 0.5f) {
			y = Mathf.FloorToInt (eulerN.y);
		}
		else
		{
			y = Mathf.CeilToInt (eulerN.y);
		}
		if ((eulerN.z % (Mathf.FloorToInt (eulerN.z))) < 0.5f) {
			z = Mathf.FloorToInt (eulerN.z);
		}
		else
		{
			z = Mathf.CeilToInt (eulerN.z);
		}

		//Arduino accepted a string with three ints, spaced by commas, and ending with a newline. Ex: 1,1,1/n
		string eulerStr = x + "," + y + "," + z + "/n";
		
		return eulerStr;
	}

	//Sends rotation in euler form to sendNum function within SendingToSP script
	public void toSendNum ()
	{
		//used 5 different anchor rotation values from Oculus. CenterEye, LeftEye, and RightEye successfully translated
		if (Input.GetKey ("h")) {
			eulerRot = EulerFloatToInt (trackingSpace.localRotation.eulerAngles);
			SendingToSP.sendNum (eulerRot);
		} else if (Input.GetKey ("j")) {
			eulerRot = EulerFloatToInt (trackerAnchor.localRotation.eulerAngles);
			SendingToSP.sendNum (eulerRot);
		} else if (Input.GetKey ("k")) {
			eulerRot = EulerFloatToInt (rightEyeAnchor.localRotation.eulerAngles);
			SendingToSP.sendNum (eulerRot);
		} else if (Input.GetKey ("l")) {
			eulerRot = EulerFloatToInt (leftEyeAnchor.localRotation.eulerAngles);
			SendingToSP.sendNum (eulerRot);
		} else {
			eulerRot = EulerFloatToInt (centerEyeAnchor.localRotation.eulerAngles);
			SendingToSP.sendNum (eulerRot);
		}
	}

}
