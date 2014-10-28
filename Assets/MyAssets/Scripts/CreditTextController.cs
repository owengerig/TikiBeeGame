using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class CreditTextController : MonoBehaviour {

        public Transform upperEdge;
        public bool removeAtUpperEdge = true;
        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {
         if (Vector2.SqrMagnitude(transform.position - upperEdge.position) < 0.1) {
                if (removeAtUpperEdge) {
                    Destroy(this.gameObject);
                } else {
                    return;
                }
            } else {
                flyCharacterToPoint();
            }
        }

        //only used in level map
        virtual public void flyCharacterToPoint() {
            Vector3 destination = upperEdge.position - transform.position;
            destination.Normalize();
            Vector3 target = destination * 2 + transform.position;
            target.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        }
    }
}
