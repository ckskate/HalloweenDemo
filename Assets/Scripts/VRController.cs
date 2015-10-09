using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class VRController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("r")) {
			InputTracking.Recenter ();
		}

		if (VRSettings.loadedDevice == VRDeviceType.Oculus) {
			VRSettings.enabled = true;
		}
	}
}
