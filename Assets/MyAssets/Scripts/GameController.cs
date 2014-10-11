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
        public int numberOfHeartsAllowed = 0;
        public int numberOfSpeedBoostsAllowed = 0;
        public int numberOfStarsAllowed = 0;
        public int numberOfPortalsAllowed = 0;


        public GameObject tikibee = null;
        public GameObject bombus = null;

        virtual public void spawnPlayers() {
            if (PreferencesManager.CURRENT_PLAYER == null) {
                if (!PreferencesManager.TIKIBEE_SELECTED && !PreferencesManager.BOMBUS_SELECTED) {
                    //PreferencesManager.setTikiBee();
                    //if (PreferencesManager.CURRENT_PLAYER == null) {
                    //    PreferencesManager.CURRENT_PLAYER = Instantiate(tikibee) as GameObject;
                    //}
                    //PreferencesManager.getPlayerController().spawn();
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
                PreferencesManager.getPlayerController().spawn();
            } else {
                PreferencesManager.getPlayerController().spawnLocationOnly();
            }
        }

        virtual public void Update() {
            if (!PreferencesManager.END_GAME) {
                if (PreferencesManager.HELI_WALLS_SPAWNED < numberOfHeliWallsAllowed) {
                    GameObject heliWallGO = Instantiate(heliWallEnemy) as GameObject;
                    heliWallGO.GetComponent<HeliWallController>().spawn();
                    PreferencesManager.HELI_WALLS_SPAWNED++;
                }
                if (PreferencesManager.HEARTS_SPAWNED < numberOfHeartsAllowed) {
                    PreferencesManager.HEARTS_SPAWNED++;
                    GameObject heartGO = Instantiate(heart) as GameObject;
                    heartGO.GetComponent<HeartController>().spawn();
                }
                if (PreferencesManager.SPEED_BOOST_SPAWNED < numberOfSpeedBoostsAllowed) {
                    PreferencesManager.SPEED_BOOST_SPAWNED++;
                    GameObject speedBoostGO = Instantiate(speedboost) as GameObject;
                    speedBoostGO.GetComponent<SpeedBoostController>().spawn();
                }
                if (PreferencesManager.STARS_SPAWNED < numberOfStarsAllowed) {
                    PreferencesManager.STARS_SPAWNED++;
                    GameObject starGO = Instantiate(star) as GameObject;
                    starGO.GetComponent<StarController>().spawn();
                }

                if (Random.value <= 0.0001) {
                    if (PreferencesManager.PORTALS_SPAWNED < numberOfPortalsAllowed) {
                        PreferencesManager.PORTALS_SPAWNED++;
                        GameObject portalGO = Instantiate(portal) as GameObject;
                        portalGO.GetComponent<PortalController>().spawn();
                    }
                }
            }
        }

    }
}
