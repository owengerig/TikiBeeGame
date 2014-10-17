using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TikiBeeGame {
    class PlayerMovementController : MonoBehaviour{

        //////////////////////////////////////////////////////////////
// CameraRelativeControl.js
// Penelope iPhone Tutorial
//
// CameraRelativeControl creates a control scheme similar to what
// might be found in 3rd person platformer games found on consoles.
// The left stick is used to move the character, and the right
// stick is used to rotate the camera around the character.
// A quick double-tap on the right joystick will make the 
// character jump. 
//////////////////////////////////////////////////////////////

public Joystick moveJoystick ;
public Joystick rotateJoystick;

Transform cameraPivot ;						// The transform used for camera rotation
Transform cameraTransform ;					// The actual transform of the camera

float speed  = 5;								// Ground speed
float jumpSpeed  = 8;
float inAirMultiplier  = 0.25f; 				// Limiter for ground speed while jumping
Vector2 rotationSpeed = new Vector2( 50f, 25f );	// Camera rotation speed for each axis

private Vector3 velocity ;						// Used for continuing momentum while in air
private bool canJump = true;

void Start()
{
	// Move the character to the correct start position in the level, if one exists
	var spawn = GameObject.Find( "PlayerSpawn" );
	if ( spawn )
		this.transform.position = spawn.transform.position;	
}

void FaceMovementDirection()
{

    Vector3 horizontalVelocity = PreferencesManager.CURRENT_PLAYER.rigidbody2D.velocity; 
	horizontalVelocity.y = 0; // Ignore vertical movement
	
	// If moving significantly in a new direction, point that character in that direction
	if ( horizontalVelocity.magnitude > 0.1 )
        this.transform.forward = horizontalVelocity.normalized;
}

void OnEndGame()
{
	// Disable joystick when the game ends	
	moveJoystick.Disable();
	rotateJoystick.Disable();
	
	// Don't allow any more control changes when the game ends
	this.enabled = false;
}

void Update()
{
	var movement = cameraTransform.TransformDirection( new Vector3( moveJoystick.position.x, 0, moveJoystick.position.y ) );
	// We only want the camera-space horizontal direction
	movement.y = 0;
	movement.Normalize(); // Adjust magnitude after ignoring vertical movement
	
	// Let's use the largest component of the joystick position for the speed.
    var absJoyPos = new Vector2(Mathf.Abs(moveJoystick.position.x), Mathf.Abs(moveJoystick.position.y));
	movement *= speed * ( ( absJoyPos.x > absJoyPos.y ) ? absJoyPos.x : absJoyPos.y );
	
	// Check for jump
    if (PreferencesManager.getPlayerController().IS_GROUNDED)
	{
		if ( !rotateJoystick.IsFingerDown() )
			canJump = true;
		
		if ( canJump && rotateJoystick.tapCount == 2 )
		{
			// Apply the current movement to launch velocity
            velocity = PreferencesManager.CURRENT_PLAYER.rigidbody2D.velocity;
			velocity.y = jumpSpeed;
			canJump = false;
		}
	}
	else
	{			
		// Apply gravity to our velocity to diminish it over time
		velocity.y += Physics.gravity.y * Time.deltaTime;
		
		// Adjust additional movement while in-air
		movement.x *= inAirMultiplier;
		movement.z *= inAirMultiplier;
	}
	
	movement += velocity;
	movement += Physics.gravity;
	movement *= Time.deltaTime;
	
	// Actually move the character
	//PreferencesManager.getPlayerController().m

    if (PreferencesManager.getPlayerController().IS_GROUNDED)
		// Remove any persistent velocity after landing
		velocity = Vector3.zero;
	
	// Face the character to match with where she is moving
	FaceMovementDirection();	
	
	// Scale joystick input with rotation speed
	var camRotation = rotateJoystick.position;
	camRotation.x *= rotationSpeed.x;
	camRotation.y *= rotationSpeed.y;
	camRotation *= Time.deltaTime;
	
	// Rotate around the character horizontally in world, but use local space
	// for vertical rotation
	cameraPivot.Rotate( 0, camRotation.x, 0, Space.World );
	cameraPivot.Rotate( camRotation.y, 0, 0 );
}



    }
}
