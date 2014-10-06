using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class MainMenuTextController : MonoBehaviour {
        void Start() {
        }
        void Update() {
        }
        public void animationFinished() {

            GameObject go = GameObject.FindGameObjectWithTag("Hud");
            if (go != null) {
                go.GetComponent<MainMenuHudController>().animationFinished();
            }
        }
    }
}
