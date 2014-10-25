using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TikiBeeGame{
    class FlameController : EnemyController{

        public bool STEADYFLAME = false;

        private ParticleSystem flameParticleSystem;
        private BoxCollider2D boxCollider;

        private bool switchAnimation = true;

        void Start() {
            this.HEALTH = -1;
            this.DAMAGE = 5;
            this.MAXDAMAGE = 99999;

            flameParticleSystem = (ParticleSystem)GetComponent("ParticleSystem");
            boxCollider = (BoxCollider2D)GetComponent("BoxCollider2D");
            //init particles
            flameParticleSystem.renderer.sortingLayerName = "Particles";
            flameParticleSystem.renderer.sortingOrder = 0;
        }

        void Update() {
            if (PreferencesManager.END_GAME) {
                flameParticleSystem.startLifetime = Random.Range(.5f, 1.1f);
                boxCollider.enabled = false;
                return;
            }
            if (switchAnimation && !STEADYFLAME) {
                if (Random.value >= 0.5) {
                    float flameAndColliderSize = Random.Range(.5f, 1.1f);
                    flameParticleSystem.startLifetime = flameAndColliderSize;
                    Vector2 colliderSize = new Vector2(1,flameAndColliderSize *  5);
                    boxCollider.size = colliderSize;
                   // boxCollider.po
                    boxCollider.enabled = true;
                } else {
                    flameParticleSystem.startLifetime = 0f;
                    boxCollider.enabled = false;
                }
                Invoke("resetSwitch", Random.Range(2f,5f));
                switchAnimation = false;
            }
        }
        private void resetSwitch() {
            switchAnimation = true;
        }

        override public void OnTriggerStay2D(Collider2D other) {
            if (other.CompareTag("Player") && MAXDAMAGE > 0) {
                giveDamge(DAMAGE / 5);
            }
        }
    }
}
