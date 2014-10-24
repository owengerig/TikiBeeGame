using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TikiBeeGame {
    class DoorController : PowerupController {
        public bool isReturnDoor = false;
        // Use this for initialization
        void Start() {
            this.HEALTHBONUS = 0;
            this.SCOREBONUS = 5;

            if (Random.value <= 0.25) {
                this.CURRENCYBONUS = 1;
            } else if (Random.value <= .1) {
                this.CURRENCYBONUS = 2;
            } else {
                this.CURRENCYBONUS = 0;
            }
        }

        // Update is called once per frame
        void Update() {
        }

        override public void OnBecameInvisible() {
        }

        override public void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                if (!PreferencesManager.END_GAME) {
                    PreferencesManager.getPlayerController().gainScore(SCOREBONUS);
                    PreferencesManager.getPlayerController().gainHealth(HEALTHBONUS);
                    PreferencesManager.getPlayerController().gainCurrency(CURRENCYBONUS);
                    teleportToSecretWorld();
                }
            }
        }

        public void teleportToSecretWorld() {
            if (isReturnDoor) {
                LevelController.returnToLevel();
            } else {
                LevelController.loadNextLevelWithLevelMap();
            }
        }
    }
}
