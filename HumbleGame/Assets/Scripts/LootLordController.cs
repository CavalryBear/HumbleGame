using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class LootLordController : MonoBehaviour {
	[Range(0.1f, 10f)]
	public float maxSpeed = 2f;
	[Range(0f, 8f)]
	public float jump = 2f;
	public Transform graphics;

	private Rigidbody2D _rigidBody;
	private bool _touchingFloor = false;
	private Animator _animator;

	// Use this for initialization
	void Awake () {
		_rigidBody = GetComponent<Rigidbody2D>();
		_animator = GetComponentInChildren<Animator>();
	}
	
	void Update (){
		if ((_touchingFloor == true) && (Input.GetKeyDown ("space"))) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jump), ForceMode2D.Impulse);
		}
	}
	
	void FixedUpdate () {
		float moveInput = Input.GetAxis("Horizontal");

		_animator.SetFloat("Speed", Mathf.Abs(moveInput));
		_rigidBody.velocity = new Vector2(moveInput * maxSpeed, _rigidBody.velocity.y);
		
		if (moveInput > 0)
			graphics.localRotation = Quaternion.Euler (0, 0, 0);
		else if (moveInput < 0)
			graphics.localRotation = Quaternion.Euler (0, 180, 0);
	}

	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag == "Ground") { 
			_touchingFloor = true;
		}
	}

	void OnCollisionExit2D(Collision2D col){

		if (col.gameObject.tag == "Ground") { 
			_touchingFloor = false;
		}
	}
	
}
