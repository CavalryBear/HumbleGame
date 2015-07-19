using UnityEngine;
using System.Collections;

public class MinionMovement : MonoBehaviour {
	public Transform target;
	public bool clockwise = true;
	public float maxSpeed = 3f;
	public float keptDistanceFromTarget;
	public Vector3 nextTargetPoint;
	public RotationQuadrants rotationQuadrant;

	private Rigidbody2D _rigidBody;


	// Use this for initialization
	void Awake () {
		_rigidBody = GetComponent<Rigidbody2D>();

		Vector3 distance = transform.position - target.position;
		keptDistanceFromTarget = (distance).magnitude;

		if (distance.x >= 0f) {
			if (distance.y >= 0f) {
				rotationQuadrant = RotationQuadrants.One;
			} else {
				rotationQuadrant = RotationQuadrants.Two;
			}
		} else {
			if (distance.y >= 0f) {
				rotationQuadrant = RotationQuadrants.Four;
			} else {
				rotationQuadrant = RotationQuadrants.Three;
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_rigidBody.velocity = Vector2.zero;
		transform.RotateAround(target.position, Vector3.forward, maxSpeed);
//		switch (rotationQuadrant) {
//		case RotationQuadrants.One:
//			break;
//		case RotationQuadrants.Two:
//			break;
//		case RotationQuadrants.Three:
//			break;
//		case RotationQuadrants.Four:
//			break;
//		}
	}

	public enum RotationQuadrants {
		One,
		Two,
		Three,
		Four
	}
}
