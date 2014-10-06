using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TikiBeeGame{
    class GameController : MonoBehaviour {
        public GameObject heliWallEnemy = null;
        public GameObject heart = null;
        public GameObject speedboost = null;
        public GameObject star = null;
        public GameObject portal = null;

        public int numberOfHeliWallsAllowed = 0;
        public int numberOfHeliWallsSpawned = 0;
        public int numberOfHeartsAllowed = 0;
        public int numberOfHeartsSpawned = 0;
        public int numberOfSpeedBoostsAllowed = 0;
        public int numberOfSpeedBoostsSpawned = 0;
        public int numberOfStarsAllowed = 0;
        public int numberOfStarsSpawned = 0;
        public int numberOfPortalsAllowed = 0;
        public int numberOfPortalsSpawned = 0;


        public GameObject tikibee = null;
        public GameObject bombus = null;

        virtual public void spawnPlayers() {
            if (PreferencesManager.CURRENT_PLAYER == null) {
                if (!PreferencesManager.TIKIBEE_SELECTED && !PreferencesManager.BOMBUS_SELECTED) {
                    //PreferencesManager.setTikiBee();
                    //if (PreferencesManager.CURRENT_PLAYER == null) {
                    //    PreferencesManager.CURRENT_PLAYER = Instantiate(tikibee) as GameObject;
                    //}
                    //((PlayerController)PreferencesManager.CURRENT_PLAYER.GetComponent<TikiBeeController>()).spawn();
                    PreferencesManager.setBombus();
                    if (PreferencesManager.CURRENT_PLAYER == null) {
                        PreferencesManager.CURRENT_PLAYER = Instantiate(bombus) as GameObject;
                    }
                } else if (PreferencesManager.TIKIBEE_SELECTED) {
                    PreferencesManager.setTikiBee();
                    if (PreferencesManager.CURRENT_PLAYER == null) {
                        PreferencesManager.CURRENT_PLAYER = Instantiate(tikibee) as GameObject;
                    }
                } else if (PreferencesManager.BOMBUS_SELECTED) {
                    PreferencesManager.setBombus();
                    if (PreferencesManager.CURRENT_PLAYER == null) {
                        PreferencesManager.CURRENT_PLAYER = Instantiate(bombus) as GameObject;
                    }
                }
                ((PlayerController)PreferencesManager.CURRENT_PLAYER.GetComponent<PlayerController>()).spawn();
            }
        }

        virtual public void Update() {
            if (!PreferencesManager.END_GAME) {
                if (numberOfHeliWallsSpawned < numberOfHeliWallsAllowed) {
                    GameObject heliWallGO = Instantiate(heliWallEnemy) as GameObject;
                    heliWallGO.GetComponent<HeliWallController>().spawn();
                    heliWallGO.GetComponent<HeliWallController>().DAMAGE = (int)Random.Range(1f, 5f);
                    numberOfHeliWallsSpawned++;
                }
                if (numberOfHeartsSpawned < numberOfHeartsAllowed) {
                    GameObject heartGO = Instantiate(heart) as GameObject;
                    heartGO.GetComponent<HeartController>().spawn();
                    numberOfHeartsSpawned++;
                }
                if (numberOfSpeedBoostsSpawned < numberOfSpeedBoostsAllowed) {
                    GameObject speedBoostGO = Instantiate(speedboost) as GameObject;
                    speedBoostGO.GetComponent<SpeedBoostController>().spawn();
                    numberOfSpeedBoostsSpawned++;
                }
                if (numberOfStarsSpawned < numberOfStarsAllowed) {
                    GameObject starGO = Instantiate(star) as GameObject;
                    starGO.GetComponent<StarController>().spawn();
                    numberOfStarsSpawned++;
                }

                if (Random.value <= 0.0001) {
                    if (numberOfPortalsSpawned < numberOfPortalsAllowed) {
                        GameObject portalGO = Instantiate(portal) as GameObject;
                        portalGO.GetComponent<PortalController>().spawn();
                        numberOfPortalsSpawned++;
                    }
                }
            }
        }

    }
}
