using UnityEngine;

namespace TikiBeeGame{
	public class HeartController : PowerupController {

		// Use this for initialization
		void Start () {
            this.HEALTHBONUS = 15;
            this.SCOREBONUS = 1;
		}
		
		// Update is called once per frame
		void Update () {
		}
        override public void DestroyMe() {
            GameObject go = GameObject.FindGameObjectWithTag("GameController");
            GameController gc = null;
            if (go != null) {
                gc = go.GetComponent<GameController>();
            }
            if (gc != null) {
                gc.numberOfHeartsSpawned--;
            }

            base.DestroyMe();
        }
	}
}
