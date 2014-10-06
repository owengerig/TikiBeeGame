//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;

namespace TikiBeeGame
{
		public class EnemyController : BaseCharacterController
		{
                public int MAXDAMAGE = 0;

				public EnemyController ()
				{
				}
                override public void OnTriggerEnter2D(Collider2D other) {
                    if (other.CompareTag("Player") && MAXDAMAGE > 0) {
                        giveDamge(this.DAMAGE);
                    }
                }

                override public void OnTriggerStay2D(Collider2D other) {
                }

                public void giveDamge(int damage) {
                    PreferencesManager.getPlayerController().takeDamage(damage);
                    MAXDAMAGE -= damage;
                }

				virtual public void spawn(){
						if (!this.gameObject.activeSelf) {
								this.gameObject.SetActive (true);
						}
			
						if (Random.value > .5) {
                            transform.position = SpawnPoint.getSpawnPointAtTopOutsideBounds();
						} else {
                            transform.position = SpawnPoint.getSpawnPointAtBottomOutsideBounds();
						}

				}

                override public void takeDamage(int damage) {
                    if (this.HEALTH == -1) {
                        return;
                    }
                    base.takeDamage(damage);
                }
		}
}

