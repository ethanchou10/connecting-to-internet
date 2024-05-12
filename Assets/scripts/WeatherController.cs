using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeatherController : MonoBehaviour {
	[SerializeField] private Material sky;
	[SerializeField] private Light sun;
	
	private float _fullIntensity;
	private float _cloudValue = 0f;
	
	// Use this for initialization
	void Start() {
		_fullIntensity = sun.intensity;
	}
	
	void Update() {
		if (_cloudValue <= 1.0f) {
			SetOvercast(_cloudValue);
			_cloudValue += .005f;
		}
	}

	private void SetOvercast(float value) {
		Debug.Log($"SetOvercast {value}");
		sky.SetFloat("_Blend", value);
		sun.intensity = _fullIntensity - (_fullIntensity * value);
	}
}
