using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TikiBeeGame {
    class BombSpawnerController : EnemyController {
        public GameObject bomb = null;
        private List<GameObject> instatiatedBombs = new List<GameObject>();
        private bool playerClose = false;

        // Use this for initialization
        void Start() {
            this.HEALTH = -1;
            this.DAMAGE = 0;
            this.MAXDAMAGE = 0;
        }

        override public void OnTriggerEnter2D(Collider2D other) {
            playerClose = true;
        }
        override public void OnTriggerStay2D(Collider2D other) {
            playerClose = true;
        }
        override public void OnTriggerExit2D(Collider2D other) {
            playerClose = false;
        }

        // Update is called once per frame
        void Update() {
            if (playerClose) {
                if (instatiatedBombs.Count == 0) {
                    GameObject tempBomb = Instantiate(bomb) as GameObject;
                    BombController bombController = tempBomb.GetComponent<BombController>();
                    bombController.spawn();
                    instatiatedBombs.Add(tempBomb);
                }
                if (instatiatedBombs[0] == null) {
                    instatiatedBombs.Clear();
                }
            }
        }
    }
}
