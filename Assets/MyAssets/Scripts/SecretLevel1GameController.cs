using UnityEngine;

namespace TikiBeeGame {
    class SecretLevel1GameController:GameController {
        private bool spawnedPowerups = false;

        void Start() {
            numberOfHeliWallsAllowed = 0;
            numberOfHeliWallsSpawned = 0;
            numberOfHeartsAllowed = 0;
            numberOfHeartsSpawned = 0;
            numberOfSpeedBoostsAllowed = 0;
            numberOfSpeedBoostsSpawned = 0;
            numberOfStarsAllowed = 0;
            numberOfStarsSpawned = 0;
            numberOfPortalsAllowed = 0;
            numberOfPortalsSpawned = 0;

            spawnPlayers();
        }

        override public void Update() {
            if (!spawnedPowerups) {
                int i = 0;
                int starsSpawned = 0;
                int heartsSpawned = 0;

                while (i <= 20) {
                    if (starsSpawned < 20) {
                        GameObject starGO = Instantiate(star) as GameObject;
                        starGO.GetComponent<StarController>().spawn();
                        starsSpawned++;
                    }
                    if (heartsSpawned < 4) {
                        GameObject heartGO = Instantiate(heart) as GameObject;
                        heartGO.GetComponent<HeartController>().spawn();
                        heartsSpawned++;
                    }
                    i++;
                }
                spawnedPowerups = true; 
            }
        }
    }
}
