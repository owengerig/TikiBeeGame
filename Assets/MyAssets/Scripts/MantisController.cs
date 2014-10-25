using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class MantisController : EnemyController {
        private Vector3 direction;
        private Vector3 startingPosition;

        public float walkingOffsetX; //how much it moves from the starting position (on both left and right side).
        public float speed;
        public float startingDirection = 1; //1 right, -1 left

        void Start() {
            this.HEALTH = 30;
            this.DAMAGE = 5;
            this.MAXDAMAGE = 100;


            startingPosition = transform.position;

            if (startingDirection == 1)
                direction = new Vector3(1.0f, 0.0f, 0.0f);
            else if (startingDirection == -1)
                direction = new Vector3(-1.0f, 0.0f, 0.0f);
            else
                direction = new Vector3(1.0f, 0.0f, 0.0f);
        }
        void Update() {
            transform.position += direction * speed * Time.deltaTime;

            if (Mathf.Abs(transform.position.x - startingPosition.x) >= walkingOffsetX) {
                flip();
                direction = -direction;
            }
        }

        void FixedUpdate() {
            //anim.SetFloat("Speed", speed * direction.x);
        }

        private void flip() {
            //flip local scale to ease tracking facing
            //flipping the world so we dont need seperate animations for movign different directions
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        void OnBecameInvisible() {
            //GameObject go = GameObject.FindGameObjectWithTag("GameController");
            //GameController gc = null;
            //if (go != null) {
            //    gc = go.GetComponent<GameController>();
            //}

            //if (this.gameObject != null) {
            //    base.DestroyMe();
            //}
        }

        override public void spawn() {
            if (!this.gameObject.activeSelf) {
                this.gameObject.SetActive(true);
            }


            rigidbody2D.gravityScale = Random.Range(-1f, 1f);
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

        //implement knock back then let base handle the rest
        override public void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player") && MAXDAMAGE > 0) {
                PreferencesManager.getPlayerController().knockBack(650);
                giveDamge(this.DAMAGE);
            }
        }
    }
}
