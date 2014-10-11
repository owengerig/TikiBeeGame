using UnityEngine;

namespace TikiBeeGame {
    class Level4GameController : GameController {
        void Start() {
            numberOfHeliWallsAllowed = 5;
            numberOfHeartsAllowed = 5;
            numberOfSpeedBoostsAllowed = 0;
            numberOfStarsAllowed = 5;
            numberOfPortalsAllowed = 1;

            spawnPlayers();
        }
    }
}
