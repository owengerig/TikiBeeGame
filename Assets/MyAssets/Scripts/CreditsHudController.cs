using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TikiBeeGame {
    public class CreditsHudController : HudController {

        public GUIStyle totalScoreLabelStyle;
        public ParticleEmitter fireworkParticleSystem;
        private List<ParticleEmitter> instantiatedFireworkParticleSystem = new List<ParticleEmitter>();

        void Start() {
        }

        // Update is called once per frame
        void Update() {
            runEmitter(fireworkParticleSystem);
            if (instantiatedFireworkParticleSystem.Count < UnityEngine.Random.Range(0f, 2f)) {
                ParticleEmitter pe = Instantiate(fireworkParticleSystem) as ParticleEmitter;
                pe.transform.position = new Vector3(UnityEngine.Random.Range(-2f, 2f), UnityEngine.Random.Range(-2f, 2f), 1f);
                instantiatedFireworkParticleSystem.Add(pe);
            }
            Invoke("moveFireworks", 2);
            Invoke("stopFireworks", 20);
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
            GUI.Label(new Rect(1200, bottonBottom, 300, 100), "Total Score: " + score, totalScoreLabelStyle);
            GUI.Label(new Rect(1200, bottonBottom+100, 300, 100), "High Score: " + PreferencesManager.getPlayerHighScoreAndUpdate(), totalScoreLabelStyle);

        }

        public void moveFireworks() {
            foreach (ParticleEmitter pe in instantiatedFireworkParticleSystem) {
                pe.transform.position = SpawnPoint.getSpawnPointAtRandomInsideBoundsExcludeHud();
            }
        }
        public void stopFireworks() {
            foreach (ParticleEmitter pe in instantiatedFireworkParticleSystem) {
                pe.emit = false;
            }
        }
    }
}