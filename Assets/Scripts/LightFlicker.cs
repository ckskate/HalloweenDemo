using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	public Light FlickerLight;
	public float threshold;
	private float random;

	void Start () {
		FlickerLight.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}
}
