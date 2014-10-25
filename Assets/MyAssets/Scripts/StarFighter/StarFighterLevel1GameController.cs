using UnityEngine;

namespace TikiBeeGame {
    class StarFighterLevel1GameController : GameController {
        public GameObject titan = null;
        void Start() {
            numberOfHeliWallsAllowed = 0;
            numberOfHeartsAllowed = 0;
            numberOfSpeedBoostsAllowed = 0;
            numberOfStarsAllowed = 0;
            numberOfPortalsAllowed = 0;

            //spawnPlayers();  no need to spawn players at this time
        }
        override public void Update() {
            if (!PreferencesManager.CURRENT_PLAYER) {
                PreferencesManager.CURRENT_PLAYER = titan;
            }
        }
    }
}
