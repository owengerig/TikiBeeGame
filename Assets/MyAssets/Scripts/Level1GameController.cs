using UnityEngine;

namespace TikiBeeGame {
    class Level1GameController : GameController {
        void Start() {
            numberOfHeliWallsAllowed = 2;
            numberOfHeartsAllowed = 2;
            numberOfSpeedBoostsAllowed = 0;
            numberOfStarsAllowed = 2;
            numberOfPortalsAllowed = 1;

            spawnPlayers();
        }
    }
}
