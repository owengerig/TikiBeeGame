using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class MainMenuController : MonoBehaviour {

        // Use this for initialization
        void Start() {
            PreferencesManager.setDefaults();
            PersistantData.checkForUpdates();
        if (Time.timeScale < 1) {
            Time.timeScale = 1;
        }
	}

        // Update is called once per frame
        void Update() {

        }
    }
}
