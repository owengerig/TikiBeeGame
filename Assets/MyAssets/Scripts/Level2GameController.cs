using UnityEngine;

namespace TikiBeeGame {
    class Level2GameController : GameController {
        void Start() {
            numberOfHeliWallsAllowed = 3;
            numberOfHeartsAllowed = 3;
            numberOfSpeedBoostsAllowed = 0;
            numberOfStarsAllowed = 3;
            numberOfPortalsAllowed = 1;

            spawnPlayers();
        }
    }
}
