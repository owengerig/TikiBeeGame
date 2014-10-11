using UnityEngine;
using System.Collections;

namespace TikiBeeGame{
	public class HeliWallController : EnemyController {

		void Start () {
            this.HEALTH = 100;
            this.DAMAGE = 5;
            this.MAXDAMAGE = 30;
		}
		
		void Update () {
		}

        void OnBecameInvisible() {
            Invoke("DestroyMe", 2f);
        }

        public override void DestroyMe() {
            PreferencesManager.HELI_WALLS_SPAWNED--;
            if (this.gameObject != null) {
                base.DestroyMe();
            }
        }

		public void SetColliderForSprite( int spriteNum )
		{
		}

		override public void spawn(){

            DAMAGE = (int)Random.Range(1f, 5f);
            MAXDAMAGE = (int)Random.Range(30f, 50f);

			if (!this.gameObject.activeSelf) {
				this.gameObject.SetActive (true);
			}


			rigidbody2D.gravityScale = Random.Range(-1.2f, 1.2f);
			if (rigidbody2D.gravityScale >= 0) {
                //falling down
				transform.position = SpawnPoint.getSpawnPointAtTopOutsideBounds();
				rigidbody2D.angularVelocity = Random.Range(-20f, 20f);
				rigidbody2D.velocity = new Vector2(Random.Range(-1f, 3f), 0);
            } else {
                //floating up
                transform.position = SpawnPoint.getSpawnPointAtBottomOutsideBounds();
				rigidbody2D.angularVelocity = Random.Range(-1f, 1f);
				rigidbody2D.velocity = new Vector2(0, 0);
				transform.rotation = new Quaternion(0, 0, 0, 0);  //reset sprite (should not go upwards, up side down)
			}
		}
	}
}
