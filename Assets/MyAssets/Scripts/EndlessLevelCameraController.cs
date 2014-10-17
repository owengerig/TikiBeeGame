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

        private float leftWall = 0;
        private float rightWall = 0;
        private float bottomWall = 0;
        private float topWall = 0;

        void Start() {

        }
        void updateWalls() {

            leftWall = camera.WorldToScreenPoint(leftEndMarker.position).x;
            rightWall = camera.WorldToScreenPoint(rightEndMarker.position).x - Screen.width;
            bottomWall = camera.WorldToScreenPoint(bottomEndMarker.position).y;
            topWall = camera.WorldToScreenPoint(topEndMarker.position).y - Screen.height;
        }

        // Update is called once per frame
        void Update() {
            updateWalls();
            if (PreferencesManager.CURRENT_PLAYER.transform) {
                Vector3 delta = PreferencesManager.CURRENT_PLAYER.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = (transform.position + delta);

                //destination = findBestPlacement(destination);
                if (destination.x > rightWall) {
                    destination = new Vector3(rightWall, destination.y, 0);
                }
                if (destination.x < leftWall) {
                    destination = new Vector3(leftWall, destination.y, 0);
                }
                if (destination.y > topWall) {
                    destination = new Vector3(destination.x, topWall, 0);
                }
                if (destination.y < bottomWall) {
                    destination = new Vector3(destination.x, bottomWall, 0);
                }

                // here to always set the Z
                destination = new Vector3(destination.x, destination.y, transform.position.z);

                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            }
        }

        private Vector3 findBestPlacement(Vector3 destination){
            bool bestPlaced = false;

            while (!bestPlaced) {
                bool adjusted = false;
                if (destination.x < leftWall) {
                    destination = new Vector3(leftWall, destination.y, destination.z);
                    adjusted = true;
                }
                if (destination.x > rightWall) {
                    destination = new Vector3(rightWall, destination.y, destination.z);
                    adjusted = true;
                }
                if (destination.y > topWall) {
                    destination = new Vector3(destination.x, topWall, destination.z);
                    adjusted = true;
                }
                if (destination.y < bottomWall) {
                    destination = new Vector3(destination.x, bottomWall, destination.z);
                    adjusted = true;
                }
                if (!adjusted) {
                    bestPlaced = true;
                }
            }
            return destination;
        }
    }
}
