using UnityEngine;
using System.Collections;

public class CameraEffects : MonoBehaviour {

	public float shakeDuration;
	public float shakeAmount;
	public float decreaseFactor;

	private Vector3 _originalPosition;

	void Awake() {
		_originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (shakeDuration > 0) {
			transform.position = _originalPosition + (Vector3)(Random.insideUnitCircle * shakeAmount);
			shakeDuration -= Time.deltaTime * decreaseFactor;
		} else {
			shakeDuration = 0f;
			transform.position = _originalPosition;
		}
	}

	public void Shake(float amount) {
		shakeDuration = amount;
	}
}
