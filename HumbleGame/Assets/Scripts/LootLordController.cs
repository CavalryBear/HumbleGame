using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class LootLordController : MonoBehaviour {
	[Range(0.1f, 10f)]
	public float maxSpeed = 2f;
	[Range(0f, 8f)]
	public float jump = 2f;
	public Transform graphics;
	public SkeletonAnimation skeleton;

	private Rigidbody2D _rigidBody;
	private bool _touchingFloor = false;
	private string currentAnimation = "";

	// Use this for initialization
	void Awake () {
		_rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void Update (){
		if ((_touchingFloor == true) && (Input.GetKeyDown ("space"))) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jump), ForceMode2D.Impulse);
		}
	}
	
	void FixedUpdate () {
		float moveInput = Input.GetAxis("Horizontal");
		_rigidBody.velocity = new Vector2(moveInput * maxSpeed, _rigidBody.velocity.y);
		
		if (moveInput > 0) {
			graphics.localRotation = Quaternion.Euler (0, 0, 0);
			SetAnimation ("walking", true);

		} else if (moveInput < 0) {
			graphics.localRotation = Quaternion.Euler (0, 180, 0);
			SetAnimation ("walking", true);
		} else {
			SetAnimation("idle",true);
		}
		
	}

	void SetAnimation (string name, bool loop){
		if (currentAnimation == name)
			return;
		skeleton.state.SetAnimation(0,name,loop);
		currentAnimation = name;
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
