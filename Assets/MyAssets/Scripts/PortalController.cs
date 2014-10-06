using UnityEngine;


namespace TikiBeeGame {
    class PortalController : PowerupController {
        public bool isReturnPortal = false;
        // Use this for initialization
        void Start() {
            this.HEALTHBONUS = 10;
            this.SCOREBONUS = 5;
        }

        // Update is called once per frame
        void Update() {
            if (!isReturnPortal) {
                Invoke("DestroyMe", 8f);
            }
        }

        override public void DestroyMe() {
            GameObject go = GameObject.FindGameObjectWithTag("GameController");
            GameController gc = null;
            if (go != null) {
                gc = go.GetComponent<GameController>();
            }
            if (gc != null) {
                gc.numberOfPortalsSpawned--;
            }

            base.DestroyMe();
        }

        override public void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                base.OnTriggerEnter2D(other);
                if (!PreferencesManager.END_GAME) {
                    teleportToSecretWorld();
                }
            }
        }

        public void teleportToSecretWorld() {
            if (isReturnPortal) {
                LevelController.returnToLevel();
            } else {
                LevelController.loadSecretLevel1Scene();
            }
        }
    }
}
