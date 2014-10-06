using UnityEngine;

namespace TikiBeeGame {
    class Level3GameController : GameController {
        void Start() {
            numberOfHeliWallsAllowed = 3;
            numberOfHeliWallsSpawned = 0;
            numberOfHeartsAllowed = 2;
            numberOfHeartsSpawned = 0;
            numberOfSpeedBoostsAllowed = 0;
            numberOfSpeedBoostsSpawned = 0;
            numberOfStarsAllowed = 8;
            numberOfStarsSpawned = 0;
            numberOfPortalsAllowed = 1;
            numberOfPortalsSpawned = 0;

            spawnPlayers();
        }
    }
}
