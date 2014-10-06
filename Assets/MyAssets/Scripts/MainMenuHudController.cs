using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class MainMenuHudController : HudController {

        private int secretPressed = 0;

        public GUIStyle secretButtonStyle;
        public GUIStyle versionLabelStyle;

        public bool animationDidFinish;
        
        void Start() {
            animationDidFinish = false;
        }

        // Update is called once per frame
        void Update() {

        }

        void OnGUI() {
            if (!animationDidFinish) {
                return; 
            }
            /*
             * handles scaling of ui
             * taken from:
             * http://answers.unity3d.com/questions/169056/bulletproof-way-to-do-resolution-independant-gui-s.html
             */
            float native_width = 1920;
            float native_height = 1080;

            //set up scaling
            float rx = Screen.width / native_width;
            float ry = Screen.height / native_height;
            GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(rx, ry, 1));
            /////////////////////////////////////////////////////////////////////

            float bottonBottom = 20;
            if (GUI.Button(new Rect(300, bottonBottom, 270, 60), "Start Game", menuButtonStyle)) {
                LevelController.loadCharacterSelection();
            }
            if (GUI.Button(new Rect(300, bottonBottom += 70, 270, 60), "Settings", menuButtonStyle)) {
                LevelController.loadSettings();
			}

            if (GUI.Button(new Rect(1800, 970, 90, 90), "", secretButtonStyle)) {
                if (secretPressed >= 8) {
                    secretPressed = 0;
                    SaveObject so = PersistantData.Load();
                    so.PLAYER_CURRENCY += 1000;
                    PersistantData.Save(so);
                } else {
                    secretPressed += 1;
                }
            }
            GUI.Label(new Rect(25, 970, 300, 100), "Version: " + PreferencesManager.GAME_VERSION, versionLabelStyle);

        }
        public void animationFinished(){
            animationDidFinish = true;
        }
    }
}