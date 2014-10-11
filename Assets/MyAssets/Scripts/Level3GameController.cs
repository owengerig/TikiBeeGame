using UnityEngine;

namespace TikiBeeGame {
    class Level3GameController : GameController {
        void Start() {
            numberOfHeliWallsAllowed = 4;
            numberOfHeartsAllowed = 4;
            numberOfSpeedBoostsAllowed = 0;
            numberOfStarsAllowed = 4;
            numberOfPortalsAllowed = 1;

            spawnPlayers();
        }
    }
}
