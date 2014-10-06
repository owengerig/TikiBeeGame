using UnityEngine;

namespace TikiBeeGame {
    class Level4GameController : GameController {
        void Start() {
            numberOfHeliWallsAllowed = 2;
            numberOfHeliWallsSpawned = 0;
            numberOfHeartsAllowed = 1;
            numberOfHeartsSpawned = 0;
            numberOfSpeedBoostsAllowed = 0;
            numberOfSpeedBoostsSpawned = 0;
            numberOfStarsAllowed = 4;
            numberOfStarsSpawned = 0;
            numberOfPortalsAllowed = 1;
            numberOfPortalsSpawned = 0;

            spawnPlayers();
        }
    }
}
