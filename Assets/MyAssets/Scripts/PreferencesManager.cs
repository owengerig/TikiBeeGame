using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TikiBeeGame {
    static class PreferencesManager {

        static public string GAME_VERSION = "0.0.1.495";

        static public bool END_GAME = false;  //used for signalling to the game controller to stop spawning because of endgame
        static public bool TIKIBEE_SELECTED = false;
        static public bool BOMBUS_SELECTED = false;
        static public bool IS_WALKING = true; // false is for flying, true is for walking
        static public int DESTINATION_LEVEL_INDEX = 0;  //used when returning from secret levels and level map controller
        static public int SOURCE_LEVEL_INDEX = 0;  //used by level map controller
        static public int DESTINATION_LEVEL_SCORE_REQUIREMENT = 0;  //used when returning from secret levels
        static public GameObject CURRENT_PLAYER = null;


        public static int HELI_WALLS_SPAWNED = 0;
        public static int HEARTS_SPAWNED = 0;
        public static int SPEED_BOOST_SPAWNED = 0;
        public static int STARS_SPAWNED = 0;
        public static int PORTALS_SPAWNED = 0;

        public static void setDefaults() {
            END_GAME = false;
            TIKIBEE_SELECTED = false;
            BOMBUS_SELECTED = false;
            IS_WALKING = true;
            DESTINATION_LEVEL_INDEX = 0;
            SOURCE_LEVEL_INDEX = 0;
            DESTINATION_LEVEL_SCORE_REQUIREMENT = 0; 
            CURRENT_PLAYER = null;

            HELI_WALLS_SPAWNED = 0;
            HEARTS_SPAWNED = 0;
            SPEED_BOOST_SPAWNED = 0;
            STARS_SPAWNED = 0;
            PORTALS_SPAWNED = 0;
        }
        public static PlayerController getPlayerController() {
            if (CURRENT_PLAYER == null) { return null; }
            return CURRENT_PLAYER.GetComponent<PlayerController>();
        }
        public static void setWalkMovement(){
            IS_WALKING = true;
        }
        public static void setFlyMovement(){
            IS_WALKING = false;
        }
        public static void setBombus(){
            BOMBUS_SELECTED = true;
            TIKIBEE_SELECTED = false;
        }
        public static void setTikiBee() {
            TIKIBEE_SELECTED = true;
            BOMBUS_SELECTED = false;
        }
        public static int getPlayerHighScoreAndUpdate() {
            SaveObject so = PersistantData.Load();
            int currentScore = getPlayerController().SCORE;
            if (currentScore > so.PLAYER_HIGH_SCORE) {
                so.PLAYER_HIGH_SCORE = currentScore;
                PersistantData.Save(so);
                return currentScore;
            } else {
                return so.PLAYER_HIGH_SCORE;
            }
        }
    }
}
