using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class LootLordController : MonoBehaviour {
	public float maxSpeed = 10f;

	private bool _facingRight = true;
	private Rigidbody2D _rigidBody;

	// Use this for initialization
	void Awake () {
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		float moveInput = Input.GetAxis("Horizontal");

		_rigidBody.velocity = new Vector2(moveInput * maxSpeed, _rigidBody.velocity.y);

		if (moveInput > 0 && !_facingRight) {
			flip();
		} else if (moveInput < 0 && _facingRight) {
			flip();
		}
	}

	private void flip() {
		_facingRight = !_facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
