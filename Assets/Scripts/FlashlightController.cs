using UnityEngine;
using System.Collections;

public class FlashlightController : MonoBehaviour {

	public Light Flashlight;
	private float random;
	public float threshold;
	private bool doFlicker;
	public AudioSource click;
	public AudioSource hum;

	// Use this for initialization
	void Start () {
		Flashlight.enabled = false;
		doFlicker = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f")) {
			Flashlight.enabled = !Flashlight.enabled;
			doFlicker = !doFlicker;
			click.Play();
			hum.Stop ();
		}
		if (doFlicker) {
			Flicker ();
			hum.Play ();
		}
	}

	void Flicker () {
		random = Random.value;
		
		if (random <= threshold) {
			Flashlight.intensity = 8;
		} else {
			Flashlight.intensity = 0;
			hum.Pause ();
		}
	}
}
