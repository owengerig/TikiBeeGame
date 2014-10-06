using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class CreditsHudController : HudController {

        public GUIStyle totalScoreLabelStyle;

        void Start() {
        }

        // Update is called once per frame
        void Update() {

        }

        void OnGUI() {
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
            if (GUI.Button(new Rect(300, bottonBottom, 270, 60), "Main Menu", menuButtonStyle)) {
                LevelController.loadMainMenuScene();
            }
            int score = 0;
            if (PreferencesManager.getPlayerController() != null) {
                score = PreferencesManager.getPlayerController().SCORE;
            }
            GUI.Label(new Rect(1300, bottonBottom, 300, 100), "Total Score: " + score, totalScoreLabelStyle);

        }
    }
}