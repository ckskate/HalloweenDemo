using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text FlashlightText;
	private Color color;

	// Use this for initialization
	void Start () {
		color = FlashlightText.color;
	}

	void Update () {
		if (color.a > .7f) {
			color.a -= .03f * Time.deltaTime;
			FlashlightText.color = color;
		} else if (color.a > 0f) {
			color.a -= .5f * Time.deltaTime;
			FlashlightText.color = color;
		} else {
			Destroy (FlashlightText);
		}
	}
}