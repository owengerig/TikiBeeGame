using System.Collections;
using UnityEngine;

namespace TikiBeeGame {
    public class BulletController : ProjectileController {

        // Use this for initialization
        void Start() {
            DAMAGE = 10;
            if (PreferencesManager.getPlayerController().MOVING_RIGHT) {
                rigidbody2D.AddForce(new Vector2(2500, 0));
            } else {
                rigidbody2D.AddForce(new Vector2(-2500, 0));
            }
        }

        // Update is called once per frame
        void Update() {

        }
    }
}