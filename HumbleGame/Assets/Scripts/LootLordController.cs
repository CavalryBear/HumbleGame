using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class LootLordController : MonoBehaviour {
	public float maxSpeed = 10f;
	public float jump = 2f;

	private bool _facingRight = true;
	private Rigidbody2D _rigidBody;
	private bool _touchingFloor = true;

	// Use this for initialization
	void Awake () {
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
<<<<<<< Updated upstream
		float moveInput = Input.GetAxis("Horizontal");

		_rigidBody.velocity = new Vector2(moveInput * maxSpeed, _rigidBody.velocity.y);

		if (_touchingFloor == true) {
			if (Input.GetKeyDown ("space")){
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
				_touchingFloor = false;
			}
		}

		if (moveInput > 0 && !_facingRight) {
=======
		float moveInputHorizontal = Input.GetAxis("Horizontal");
		
		_rigidBody.velocity = new Vector2(moveInputHorizontal * maxSpeed, Input.GetAxis("Vertical") * maxSpeed);
		
		if (moveInputHorizontal > 0 && !_facingRight) {
>>>>>>> Stashed changes
			flip();
		} else if (moveInputHorizontal < 0 && _facingRight) {
			flip();
		}

	}

	 void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == "Ground") { 
			_touchingFloor = true;
		}
		
	}

	private void flip() {
		_facingRight = !_facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
