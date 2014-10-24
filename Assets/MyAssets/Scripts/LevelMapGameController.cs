using UnityEngine;

namespace TikiBeeGame {
    class LevelMapGameController : GameController {
        public Transform mainMenuArea = null;
        public Transform level1Area = null;
        public Transform level2Area = null;
        public Transform level3Area = null;
        public Transform level4Area = null;

        private Vector2 destination = Vector2.zero;
        private bool moving = false;

        private bool playerMovementStyleSave = false;

        void Start() {
            numberOfHeliWallsAllowed = 0;
            numberOfHeartsAllowed = 0;
            numberOfSpeedBoostsAllowed = 0;
            numberOfStarsAllowed = 0;
            numberOfPortalsAllowed = 0;

            spawnPlayers();

            //save the current setting for movement style
            playerMovementStyleSave = PreferencesManager.IS_WALKING;

            PreferencesManager.setFlyMovement();

            switch (PreferencesManager.SOURCE_LEVEL_INDEX) {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    PreferencesManager.CURRENT_PLAYER.transform.position = mainMenuArea.position;
                    break;
                case 5:
                    PreferencesManager.CURRENT_PLAYER.transform.position = level1Area.position;
                    break;
                case 6:
                    PreferencesManager.CURRENT_PLAYER.transform.position = level2Area.position;
                    break;
                case 7:
                    PreferencesManager.CURRENT_PLAYER.transform.position = level3Area.position;
                    break;
                case 8:
                    PreferencesManager.CURRENT_PLAYER.transform.position = level4Area.position;
                    break;
                default:
                    PreferencesManager.CURRENT_PLAYER.transform.position = mainMenuArea.position;
                    break;
            }
            switch (PreferencesManager.DESTINATION_LEVEL_INDEX) {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    destination = new Vector2(mainMenuArea.position.x, mainMenuArea.position.y);
                    break;
                case 5:
                    destination = new Vector2(level1Area.position.x, level1Area.position.y);
                    break;
                case 6:
                    destination = new Vector2(level2Area.position.x, level2Area.position.y);
                    break;
                case 7:
                    destination = new Vector2(level3Area.position.x, level3Area.position.y);
                    break;
                case 8:
                    destination = new Vector2(level4Area.position.x, level4Area.position.y);
                    break;
                default:
                    destination = new Vector2(mainMenuArea.position.x, mainMenuArea.position.y);
                    break;
            }
        }


        void OnGUI() {
            //INTERCEPT ALL INPUT
            Event e = Event.current;
            if (e.type == EventType.MouseDown) {
                PreferencesManager.getPlayerController().guiClick = true;
            }
        }

        //this overrides base implementation and prevents spawning regardless of the numbers above
        override public void Update() {
            if (PreferencesManager.CURRENT_PLAYER != null) {
                Vector2 player = new Vector2(PreferencesManager.CURRENT_PLAYER.transform.position.x, PreferencesManager.CURRENT_PLAYER.transform.position.y);
                if (Vector2.SqrMagnitude(player - destination) < 0.001) {
                    PreferencesManager.CURRENT_PLAYER.SetActive(false);
                    PreferencesManager.IS_WALKING = playerMovementStyleSave;
                    LevelController.loadLevel(PreferencesManager.DESTINATION_LEVEL_INDEX);
                    PreferencesManager.END_GAME = false;
                } else if (!moving) {
                    PreferencesManager.getPlayerController().flyCharacterToPoint(new Vector3(destination.x, destination.y, PreferencesManager.CURRENT_PLAYER.transform.position.z));
                    moving = true;
                }
            }
        }
    }
}
