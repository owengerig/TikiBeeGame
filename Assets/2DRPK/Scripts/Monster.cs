using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Monster : MonoBehaviour {

	private Animator anim;
	private Vector3 direction;
	private Vector3 startingPosition;

	public float walkingOffsetX; //how much it moves from the starting position (on both left and right side).
	public float speed;
	public float startingDirection = 1; //1 right, -1 left

	void Awake() {
		anim = GetComponent<Animator>();

	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	

}
