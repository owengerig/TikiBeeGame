using UnityEngine;

namespace TikiBeeGame {
    class Level2GameController : GameController {
        void Start() {
            numberOfHeliWallsAllowed = 2;
            numberOfHeliWallsSpawned = 0;
            numberOfHeartsAllowed = 1;
            numberOfHeartsSpawned = 0;
            numberOfSpeedBoostsAllowed = 0;
            numberOfSpeedBoostsSpawned = 0;
            numberOfStarsAllowed = 6;
            numberOfStarsSpawned = 0;
            numberOfPortalsAllowed = 1;
            numberOfPortalsSpawned = 0;

            spawnPlayers();
        }
    }
}
