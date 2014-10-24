using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TikiBeeGame {
    class EndlessLevelCameraController : MonoBehaviour {
        //public float speed = 2f;
        public float dampTime = 0.15f;
        private Vector3 velocity = Vector3.zero;
        public Transform rightEndMarker = null;
        public Transform leftEndMarker = null;
        public Transform topEndMarker = null;
        public Transform bottomEndMarker = null;
        public bool useFixedUpdate = false;
        public bool pinCamera = false;

        private float leftWallXWorld = 0;
        private float leftWallXScreen = 0;
        private float rightWallXWorld = 0;
        private float rightWallXScreen = 0;
        private float topWallYWorld = 0;
        private float topWallYScreen = 0;
        private float bottomWallYWorld = 0;
        private float bottomWallYScreen = 0;

        void Start() {

        }
        void updateWalls() {

            leftWallXWorld = leftEndMarker.position.x;
            leftWallXScreen = camera.WorldToScreenPoint(leftEndMarker.position).x;

            rightWallXWorld = rightEndMarker.position.x - Screen.width;
            rightWallXScreen = camera.WorldToScreenPoint(rightEndMarker.position).x - Screen.width;

            topWallYWorld = topEndMarker.position.y - Screen.height;
            topWallYScreen = camera.WorldToScreenPoint(topEndMarker.position).y - Screen.height;

            bottomWallYWorld = bottomEndMarker.position.y;
            bottomWallYScreen = camera.WorldToScreenPoint(bottomEndMarker.position).y;
        }


        void LateUpdate() {
            if (!useFixedUpdate)
                updateCameraPosition();
        }


        void FixedUpdate() {
            if (useFixedUpdate)
                updateCameraPosition();
        }
        // Update is called once per frame
        void updateCameraPosition() {
            updateWalls();
            if (PreferencesManager.CURRENT_PLAYER.transform) {

                if (!pinCamera) {
                    Vector3 delta = PreferencesManager.CURRENT_PLAYER.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)); //(new Vector3(0.5, 0.5, point.z));
                    Vector3 destination = (transform.position + delta);
                    //Vector3 destinationWorld = camera.ScreenToWorldPoint(destination);
                    if (destination.x > rightWallXScreen) {
                        destination = new Vector3(rightWallXScreen, destination.y, 0);
                    }
                    if (destination.x < leftWallXScreen) {
                        destination = new Vector3(leftWallXScreen, destination.y, 0);
                    }
                    if (destination.y > topWallYScreen) {
                        destination = new Vector3(destination.x, topWallYScreen, 0);
                    }
                    if (destination.y < bottomWallYScreen) {
                        destination = new Vector3(destination.x, bottomWallYScreen, 0);
                    }
                    // here to always set the Z
                    destination = new Vector3(destination.x, destination.y, transform.position.z);

                    transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
                }

                //Logger.logTest("step1");
                float playerX = PreferencesManager.CURRENT_PLAYER.transform.position.x;
                float playerY = PreferencesManager.CURRENT_PLAYER.transform.position.y;
                if ((Math.Abs(playerX - leftEndMarker.position.x) < .5 && !PreferencesManager.getPlayerController().MOVING_RIGHT) ||
                    (Math.Abs(playerX - rightEndMarker.position.x) < .5 && PreferencesManager.getPlayerController().MOVING_RIGHT) ||
                    (Math.Abs(playerY - topEndMarker.position.x) < .01 && PreferencesManager.getPlayerController().MOVING_UP)) {
                    // || (Math.Abs(playerY - bottomEndMarker.position.x) < .5 && !PreferencesManager.getPlayerController().MOVING_UP)) {

                    PreferencesManager.getPlayerController().MOVE_ALLOWED = false;
                    //Logger.logTest("false");
                } else {
                    PreferencesManager.getPlayerController().MOVE_ALLOWED = true;
                    //Logger.logTest("true");
                }

            }
        }
    }
}
