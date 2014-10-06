using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TikiBeeGame {
    class DoorController : PowerupController {
        // Use this for initialization
        void Start() {
            this.HEALTHBONUS = 0;
            this.SCOREBONUS = 5;

            if (Random.value <= 0.25) {
                this.CURRENCYBONUS = 1;
            } else if (Random.value <= .1) {
                this.CURRENCYBONUS = 2;
            } else {
                this.CURRENCYBONUS = 0;
            }
        }

        // Update is called once per frame
        void Update() {
        }
		
    }
}
