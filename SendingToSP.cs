using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

	/* SendingToSP script is modified code from a script called Sending, which can be found at r3dstar.co.uk. 
	 * -Changed print commands to debug.logs 
	 * -Removed red,green,yellow functions, and created a function for sending a string that contains euler info 
	 * -Removed Update function*/
public class SendingToSP : MonoBehaviour {

	public static SerialPort sp = new SerialPort("COM3", 9600);

	//float timePassed = 0.0f;

	// Use this for initialization
	void Start () {
		OpenConnection ();
	}

	public void OpenConnection ()
	{

		if (sp != null)
		{

			if (sp.IsOpen)
			{
				Debug.Log("Port already Open, closing now");
				sp.Close();

			}
			else
			{
				sp.Open();
				sp.ReadTimeout = 16;
				Debug.Log ("Port opened!");

			}

		}
		else
		{

			if (sp.IsOpen)
			{

				Debug.Log ("Port is already open");

			}
			else
			{

				Debug.Log ("Port is null");
			}
		}
	}

	void OnApllicationQuit ()
	{
		sp.Close ();
	}

	public static void sendNum (string eulerN)
	{
		sp.Write (eulerN);

	}
}

