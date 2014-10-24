
using UnityEngine;
using System.Collections;


namespace TikiBeeGame {
    public class MySmoothFollow : MonoBehaviour {
        public float smoothDampTime = 0.2f;
        [HideInInspector]
        public new Transform transform;
        public Vector3 cameraOffset;
        public bool useFixedUpdate = false;

        private PlayerController playerController;
        private Vector3 _smoothDampVelocity;


        void Awake() {
            transform = gameObject.transform;
            playerController = PreferencesManager.getPlayerController();
        }


        void LateUpdate() {
            if (!useFixedUpdate)
                updateCameraPosition();
        }


        void FixedUpdate() {
            if (useFixedUpdate)
                updateCameraPosition();
        }


        void updateCameraPosition() {
            if (playerController == null) {
                playerController = PreferencesManager.getPlayerController();
                transform.position = Vector3.SmoothDamp(transform.position, playerController.transform.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime);
                return;
            }

            if (playerController.rigidbody2D.velocity.x > 0) {
                transform.position = Vector3.SmoothDamp(transform.position, playerController.transform.position - cameraOffset, ref _smoothDampVelocity, smoothDampTime);
            } else {
                var leftOffset = cameraOffset;
                leftOffset.x *= -1;
                transform.position = Vector3.SmoothDamp(transform.position, playerController.transform.position - leftOffset, ref _smoothDampVelocity, smoothDampTime);
            }
        }

    }
}