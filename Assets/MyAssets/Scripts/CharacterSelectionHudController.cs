using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class CharacterSelectionHudController : HudController {

        public GUIStyle invisibleButtonStyle;

        // Use this for initialization
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

            if (GUI.Button(new Rect(200, 60, 230, 60), "Back", menuButtonStyle)) {
                LevelController.loadMainMenuScene();
            }
            if (GUI.Button(new Rect(35, 120, 880, 950), "", invisibleButtonStyle)) {
                PreferencesManager.setTikiBee();
                LevelController.loadStatModifierScene();
            }
            if (GUI.Button(new Rect(1040, 120, 880, 920), "", invisibleButtonStyle)) {
                PreferencesManager.setBombus();
                LevelController.loadStatModifierScene();
            }

        }
    }
}
