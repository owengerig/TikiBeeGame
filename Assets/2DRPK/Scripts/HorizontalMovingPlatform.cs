using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class HorizontalMovingPlatform : MonoBehaviour {
	float direction;
	Vector3 startingPosition;
	DistanceJoint2D joint;
	GameObject playerOnPlatform;

	public float movingDistance; //how much it moves from the starting position (on both left and right side).
	public float speed;
	public float startingDirection = 1; //1 right, -1 left


	void Awake() {
		joint = GetComponent<DistanceJoint2D>();
		rigidbody2D.isKinematic = true;
	}
	
	// Use this for initialization
	void Start () {
		startingPosition = rigidbody2D.position;
		
		direction = startingDirection;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() {

		if(Mathf.Abs(rigidbody2D.position.x - startingPosition.x) >= movingDistance) {
			direction = -direction;
		}

		//Debug.Log(rigidbody2D.position);
		Vector2 newPos = new Vector2(rigidbody2D.position.x + direction*speed*Time.deltaTime, rigidbody2D.position.y);
		rigidbody2D.MovePosition(newPos);

	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			other.gameObject.transform.parent = transform;
			playerOnPlatform = other.gameObject;
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if(playerOnPlatform)
			playerOnPlatform.transform.parent = transform;
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			other.gameObject.transform.parent = null;
			playerOnPlatform = null;
		}
	}

}
