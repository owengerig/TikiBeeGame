using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TikiBeeGame {
    class BombController : EnemyController {

        public Transform bombSpawner;

        public float bombRadius = 10f;			// Radius within which enemies are killed.
        public AudioClip boom;					// Audioclip of explosion.
        public AudioClip fuse;					// Audioclip of fuse.
        private float fuseTime = Random.Range(.7f,2);
        public float volume = .1f;

        public List<Sprite> bombSprites; //set in editor


        //private LayBombs layBombs;				// Reference to the player's LayBombs script.
        //private PickupSpawner pickupSpawner;	// Reference to the PickupSpawner script.
        public ParticleSystem explosionFX;	// Reference to the particle system of the explosion effect.
        public ParticleSystem sparksFX;	// Reference to the particle system of the explosion effect.


        virtual public void spawn() {
            this.gameObject.SetActive(true);
            this.enabled = true;
            transform.position = bombSpawner.position;
            //this.renderer.sortingLayerName = "ForeGround";
            //this.renderer.sortingOrder = 0;
        }
        
        void Awake() {
            // Setting up references.

            //pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
            //if (GameObject.FindGameObjectWithTag("Player"))
            //    layBombs = GameObject.FindGameObjectWithTag("Player").GetComponent<LayBombs>();
        }

        void Start() {

            this.HEALTH = -1;
            this.DAMAGE = Random.Range(10,35);
            this.MAXDAMAGE = 99999;

            // If the bomb has no parent, it has been laid by the player and should detonate.
            if (transform.root == transform)
                StartCoroutine(BombDetonation());

            SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
            sr.sprite = bombSprites[Random.Range(0, 21)]; ;

            runParticleSystem(sparksFX);
            sparksFX.transform.position = transform.position+(new Vector3(.5f,.5f,0f));
        }

        void Update() {
            sparksFX.transform.position = transform.position + (new Vector3(.5f, .5f, 0f));
        }

        IEnumerator BombDetonation() {
            // Play the fuse audioclip.
            AudioSource.PlayClipAtPoint(fuse, transform.position, volume);
            // Wait for 2 seconds.
            yield return new WaitForSeconds(fuseTime);

            // Explode the bomb.
            Explode();
        }

        public void Explode() {

            // The player is now free to lay bombs when he has them.
            //layBombs.bombLaid = false;

            // Make the pickup spawner start to deliver a new pickup.
            //pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());

            // Find all the colliders on the Enemies layer within the bombRadius.
            Collider2D[] players = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Player"));

            // For each collider...
            foreach (Collider2D en in players) {
                // Check if it has a rigidbody (since there is only one per enemy, on the parent).
                Rigidbody2D rb = en.rigidbody2D;
                if (rb != null && rb.tag == "Player") {
                    // Find the Enemy script and set the enemy's health to zero.
                    PreferencesManager.getPlayerController().takeDamage(DAMAGE);
                    PreferencesManager.getPlayerController().knockBack(400);
                    //float bombForce = 700f;			// Force that enemies are thrown from the blast.

                    //// Find a vector from the bomb to the enemy.
                    //Vector3 deltaPos = rb.transform.position - transform.position;

                    //// Apply a force in this direction with a magnitude of bombForce.
                    //Vector3 force = deltaPos.normalized * bombForce;
                    //rb.AddForce(force);
                }
            }

            // Set the explosion effect's position to the bomb's position and play the particle system.
            runParticleSystem(explosionFX);

            // Instantiate the explosion prefab.
            //Instantiate(explosionFX, transform.position, Quaternion.identity);


            // Play the explosion sound effect.
            AudioSource.PlayClipAtPoint(boom, transform.position, volume);

            stopParticleSystem(sparksFX);

            // Destroy the bomb.
            Destroy(gameObject);
        }
    }
}