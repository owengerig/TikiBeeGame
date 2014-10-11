using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TikiBeeGame{
    class BackgroundController : MonoBehaviour {

        public Transform exitDoor = null;

        void Start() {
        }

        void Update() {
            //exitDoor.position = Camera.main.ViewportToWorldPoint(new Vector3(.85f, .25f, 1));
        }
    }
}
