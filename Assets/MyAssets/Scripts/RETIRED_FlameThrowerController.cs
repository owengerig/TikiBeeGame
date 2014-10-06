using UnityEngine;
using System.Collections;

namespace TikiBeeGame{
	public class FlameThrowerController : EnemyController {

		
		public ParticleSystem flameParticleSystem;

		// Use this for initialization
		void Start () {
			flameParticleSystem.renderer.sortingLayerName = "Foreground";
			flameParticleSystem.renderer.sortingOrder = 0;


		}
		
		// Update is called once per frame
		void Update () {
			GameObject tbcGO = GameObject.FindGameObjectWithTag ("Player");
			if (tbcGO == null) { return; }
			// 1
			Vector3 currentPosition = transform.position;
			
			Vector3 moveToward = tbcGO.transform.position ;
			// 4
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0; 
			moveDirection.Normalize();
			
			float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = 
				Quaternion.Slerp( transform.rotation, 
				                 Quaternion.Euler( 0, 0, targetAngle ), 
				                 6 * Time.deltaTime );
		}

		Vector3[] SpriteLocalToWorld(Sprite sp) 
		{
			Vector3 pos = transform.position;
			Vector3 [] array = new Vector3[2];
			//top left
			array[0] = pos + sp.bounds.min;
			// Bottom right
			array[1] = pos + sp.bounds.max;
			return array;
		}
	}
}
