using System.Collections;
using UnityEngine;

namespace TikiBeeGame {
    class InstantDeathController : EnemyController {
        void Start() {
            this.HEALTH = -1;
            this.DAMAGE = 99999;
            this.MAXDAMAGE = 99999;
        }
        void Update() {
            if (PreferencesManager.getPlayerController() == null || PreferencesManager.END_GAME) { return; }
            float currentPlayersHealth = PreferencesManager.getPlayerController().HEALTH;

            this.DAMAGE = Mathf.RoundToInt(currentPlayersHealth * 2);
            this.MAXDAMAGE = Mathf.RoundToInt(currentPlayersHealth * 4);
        }
    }
}
