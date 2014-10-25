using System.Collections;
using UnityEngine;

namespace TikiBeeGame {
    public class ProjectileController : MonoBehaviour {

        public int DAMAGE;

        virtual public void OnBecameInvisible() {
            DestroyMe();
        }
        virtual public void DestroyMe() {
            if (this.gameObject != null) {
                Destroy(this.gameObject);
            }
        }

        virtual public void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Enemy")) {
                other.GetComponent<EnemyController>().takeDamage(DAMAGE);
            }
        }
        virtual public void OnTriggerStay2D(Collider2D other) {
        }
        virtual public void OnTriggerExit2D(Collider2D other) {
        }
    }
}
