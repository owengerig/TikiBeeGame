using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public static class LevelController {

        public static float levelFadeInTime = 1;
        public static float levelFadeOutTime = 1;
        public static float secretLeveFadeInTime = .5f;
        public static float secretLeveFadeOutTime = .5f;

        private static int MAIN_MENU_INDEX = 0;
        private static int SETTINGS_INDEX = 1;
        private static int CHAR_SELECTION_INDEX = 2;
        private static int STAT_MOD_INDEX = 3;
        private static int LEVEL_MAP_INDEX = 4;
        private static int LEVEL_1_INDEX = 5;
        private static int LEVEL_2_INDEX = 6;
        private static int LEVEL_3_INDEX = 7;
        private static int LEVEL_4_INDEX = 8;
        private static int SECRET_LEVEL_1_INDEX = 9;
        private static int CREDITS_INDEX = 10;

        public static void loadMainMenuScene() {
            if (PreferencesManager.CURRENT_PLAYER != null) { PreferencesManager.getPlayerController().DestroyMe(); }
            FadeScene.LoadLevel(MAIN_MENU_INDEX, levelFadeInTime, levelFadeOutTime, new Color(Random.value, Random.value, Random.value));
        }
        public static void loadSettings() {
            FadeScene.LoadLevel(SETTINGS_INDEX, levelFadeInTime, levelFadeOutTime, new Color(Random.value, Random.value, Random.value));
        }
        public static void loadCharacterSelection() {
            FadeScene.LoadLevel(CHAR_SELECTION_INDEX, levelFadeInTime, levelFadeOutTime, new Color(Random.value, Random.value, Random.value));
        }
        public static void loadStatModifierScene() {
            FadeScene.LoadLevel(STAT_MOD_INDEX, levelFadeInTime, levelFadeOutTime, new Color(Random.value, Random.value, Random.value));
        }
        public static void loadLevelMapScene() {
            FadeScene.LoadLevel(LEVEL_MAP_INDEX, levelFadeInTime, levelFadeOutTime, new Color(Random.value, Random.value, Random.value));
        }
        public static void loadLevel1Scene() {
            PreferencesManager.getPlayerController().saveCurrencyToPersistantStore();
            FadeScene.LoadLevel(LEVEL_1_INDEX, levelFadeInTime, levelFadeOutTime, new Color(Random.value, Random.value, Random.value));
        }
        public static void loadLevel2Scene() {
            PreferencesManager.getPlayerController().saveCurrencyToPersistantStore();
            FadeScene.LoadLevel(LEVEL_2_INDEX, levelFadeInTime, levelFadeOutTime, new Color(Random.value, Random.value, Random.value));
        }
        public static void loadLevel3Scene() {
            PreferencesManager.getPlayerController().saveCurrencyToPersistantStore();
            FadeScene.LoadLevel(LEVEL_3_INDEX, levelFadeInTime, levelFadeOutTime, new Color(Random.value, Random.value, Random.value));
        }
        public static void loadLevel4Scene() {
            PreferencesManager.getPlayerController().saveCurrencyToPersistantStore();
            FadeScene.LoadLevel(LEVEL_4_INDEX, levelFadeInTime, levelFadeOutTime, new Color(Random.value, Random.value, Random.value));
        }
        public static void loadSecretLevel1Scene() {
            if (Application.loadedLevel == SECRET_LEVEL_1_INDEX) { return; }
            PreferencesManager.DESTINATION_LEVEL_INDEX = Application.loadedLevel;
            FadeScene.LoadLevel(SECRET_LEVEL_1_INDEX, levelFadeInTime, levelFadeOutTime, Color.green);
        }
        public static void loadCreditsScene() {
            PreferencesManager.getPlayerController().saveCurrencyToPersistantStore();
            if (PreferencesManager.CURRENT_PLAYER != null) { PreferencesManager.CURRENT_PLAYER.SetActive(false); }
            FadeScene.LoadLevel(CREDITS_INDEX, levelFadeInTime, levelFadeOutTime, new Color(Random.value, Random.value, Random.value));
        }
        public static void returnToLevel() {
            loadLevel(PreferencesManager.DESTINATION_LEVEL_INDEX);
        }
        public static void reloadCurrentLevel() {
            if (PreferencesManager.CURRENT_PLAYER != null) { PreferencesManager.getPlayerController().DestroyMe(); }
            PreferencesManager.END_GAME = false;
            if (Application.loadedLevel == SECRET_LEVEL_1_INDEX) {
                returnToLevel();
            } else {
                loadLevel(Application.loadedLevel);
            }
        }
        public static void loadNextLevel() {
            //dont want to load secret level from this so check for that
            if (Application.loadedLevel + 1 == SECRET_LEVEL_1_INDEX) {
                loadLevel(Application.loadedLevel + 2);
            } else {
                loadLevel(Application.loadedLevel + 1);
            }
        }
        public static void loadNextLevelWithLevelMap() {
            //dont want to load secret level from this so check for that
            if (Application.loadedLevel + 1 == SECRET_LEVEL_1_INDEX || Application.loadedLevel + 1 == LEVEL_MAP_INDEX) {
                PreferencesManager.DESTINATION_LEVEL_INDEX = Application.loadedLevel + 2;
            } else {
                PreferencesManager.DESTINATION_LEVEL_INDEX = Application.loadedLevel + 1;
            }
            PreferencesManager.SOURCE_LEVEL_INDEX = Application.loadedLevel;

            if (PreferencesManager.DESTINATION_LEVEL_INDEX == CREDITS_INDEX) {
                loadLevel(CREDITS_INDEX);
            } else {
                loadLevel(LEVEL_MAP_INDEX);
            }
        }

        public static void loadLastLevel() {
            //dont want to load secret level from this so check for that
            if (Application.loadedLevel - 1 == SECRET_LEVEL_1_INDEX) {
                loadLevel(Application.loadedLevel - 2);
            } else {
                loadLevel(Application.loadedLevel - 1);
            }
        }
        public static void loadLastLevelWithLevelMap() {
            //dont want to load secret level from this so check for that
            if (Application.loadedLevel - 1 == SECRET_LEVEL_1_INDEX) {
                PreferencesManager.DESTINATION_LEVEL_INDEX = Application.loadedLevel - 2;
            } else {
                PreferencesManager.DESTINATION_LEVEL_INDEX = Application.loadedLevel - 1;
            }
            PreferencesManager.SOURCE_LEVEL_INDEX = Application.loadedLevel;
            loadLevel(LEVEL_MAP_INDEX);
        }

        public static void loadLevel(int index) {

            if (index > CREDITS_INDEX) {
                loadMainMenuScene();
                return;
            }

            if (index < 0) {
                loadMainMenuScene();
                return;
            }

            if (index == MAIN_MENU_INDEX) {
                loadMainMenuScene();
            }

            if (index == SETTINGS_INDEX) {
                loadSettings();
            }
            
            if (index == CHAR_SELECTION_INDEX) {
                loadCharacterSelection();
            }

            if (index == STAT_MOD_INDEX) {
                loadStatModifierScene();
            }

            if (index == LEVEL_MAP_INDEX) {
                loadLevelMapScene();
            }

            if (index == LEVEL_1_INDEX) {
                loadLevel1Scene();
            }

            if (index == LEVEL_2_INDEX) {
                loadLevel2Scene();
            }
            
            if (index == LEVEL_3_INDEX) {
                loadLevel3Scene();
            }
            
            if (index == LEVEL_4_INDEX) {
                loadLevel4Scene();
            }
            
            if (index == SECRET_LEVEL_1_INDEX) {
                loadSecretLevel1Scene();
            }
            
            if (index == CREDITS_INDEX) {
                loadCreditsScene();
            }
        }
    }
}
