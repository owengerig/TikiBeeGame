using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TikiBeeGame {
    class EndlessLevelCameraController : MonoBehaviour {
        //public float speed = 2f;
        public float dampTime = 0.15f;
        private Vector3 velocity = Vector3.zero;
        private Transform target = null;
        public Transform endMarker = null;

        private float leftWall = 0;
        private float rightWall = 8;//Screen.width/58;
        private float bottomWall = 0;
        private float topWall = 10;

        public float test;

        // Update is called once per frame
        void Update() {
            if (target) {
                Vector3 point = camera.WorldToViewportPoint(target.position);
                Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
                Vector3 destination = transform.position + delta;
                
                if (destination.x < leftWall) {
                    destination = new Vector3(leftWall, destination.y, destination.z);
                }

                test = endMarker.position.x-10f ;
                if (destination.x > test) {
                    destination = new Vector3(test, destination.y, destination.z);
                } 
                if (destination.y < bottomWall) {
                    destination = new Vector3(destination.x, bottomWall, destination.z);
                }
                if (destination.y > topWall) {
                    destination = new Vector3(destination.x, topWall, destination.z);
                }
                //OVERRIDE FOR TEST FOR Y (TOP WALL)
                //destination = new Vector3(destination.x, 0, destination.z);


                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            } else {
                if (PreferencesManager.CURRENT_PLAYER == null || PreferencesManager.END_GAME) { return; }
                target = PreferencesManager.CURRENT_PLAYER.transform;
            }
        }
    }
}
