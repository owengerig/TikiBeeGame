using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class SettingsHudController : HudController {

        public GUIStyle movementToggleStyle;

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

            if (GUI.Button(new Rect(700, 20, 230, 60), "Main Menu", menuButtonStyle)) {
                LevelController.loadMainMenuScene();
            }
            //if (GUI.Button(new Rect(300, 90, 230, 60), "Save", menuButtonStyle)) {
            //    this.loadMainMenuScene();
            //}
            if (GUI.Button(new Rect(700, 190, 400, 60), "Clear Saved Data", menuButtonStyle)) {
                PersistantData.Delete();
                LevelController.loadMainMenuScene();
            }

            if (PreferencesManager.IS_WALKING) {
                PreferencesManager.IS_WALKING = GUI.Toggle(new Rect(700, 300, 500, 60), PreferencesManager.IS_WALKING, "Default: Walking", movementToggleStyle);
            } else {
                PreferencesManager.IS_WALKING = GUI.Toggle(new Rect(700, 300, 500, 60), PreferencesManager.IS_WALKING, "Default: Flying", movementToggleStyle);
            }
        }
    }
}
