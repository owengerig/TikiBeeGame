//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Collections;
using UnityEngine;

namespace TikiBeeGame
{
		public class TEST : MonoBehaviour
		{
            //bool RAN;
            public Texture2D testIcon;

			public TEST ()
			{
			}

			void Start()
			{
			}

            void OnGUI() {
                GameObject hudGO = GameObject.FindGameObjectWithTag("Hud");
                HudController hc = hudGO.GetComponent<GameHudController>();
                //GUI.Box(new Rect(hc.shieldsButtonPositionWP.x, hc.shieldsButtonPositionWP.y, 50, 25), new GUIContent("TEST1", testIcon));
                //GUI.Box(new Rect(hc.pauseButtonPositionWP.x, hc.pauseButtonPositionWP.y, 30, 30), new GUIContent("TEST2", testIcon));
                //GUI.Box(new Rect(hc.healthButtonPositionWP.x, hc.healthButtonPositionWP.y, 70, 30), new GUIContent("TEST3", testIcon));
                //GUI.Box(new Rect(hc.scoreButtonPositionWP.x, hc.scoreButtonPositionWP.y, 70, 30), new GUIContent("TEST4", testIcon));
            }
            void Update() {
            }

			private void changePostion()
			{
				//transform.position = sp.getSpawnPointAtMiddleInsideBounds ();
				//RAN = false;
			}

            private void OnDrawGizmosSelected() {
                Gizmos.color = Color.red;
                //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
                //Gizmos.DrawSphere(transform.position, BURST_RADIUS);
            }
            private void archivedCode() {


                //if (RAN == false) {
                //		Invoke ("changePostion", 1f);
                //				RAN = true;
                //		}


                GameObject hudGO = GameObject.FindGameObjectWithTag("Hud");
                HudController hc = hudGO.GetComponent<GameHudController>();

                Rect shieldsButtonRect = new Rect(Screen.width - 50, Screen.height - 25, 50, 25);

                Vector2 position = new Vector2(Screen.width - 50, Screen.height - 25);
                Vector3 position2 = new Vector3(Screen.width - 50, Screen.height - 25, 1);

                //Vector2 p = new Vector2(hc.shieldsButtonRect.x, hc.shieldsButtonRect.y);
                //GUIUtility.GUIToScreenPoint(hc.shieldsButtonRect.position);
                //transform.position = position2;

                //Vector2 positionGui = new Vector2(hc.shieldsButtonRect.position.x, hc.shieldsButtonRect.position.y);
                //Vector3 positionGui2 = new Vector3(hc.shieldsButtonRect.position.x/2, hc.shieldsButtonRect.position.y/2,0f);

                //Vector3 pos = Camera.main.ScreenToWorldPoint(Screen.width - 10, Screen.height - 10);



                //Vector3 pos2 = Camera.main.ScreenToWorldPoint(hc.shieldsButtonRect.position);
                ////Vector3 pos3 = Camera.main.ViewportToScreenPoint(hc.shieldsButtonRect.position);
                //    pos2.x /= 2;
                //    //pos2.x += 3;

                //    pos2.y /= 2;
                //    //pos2.y += 2;
                //    pos2.y *= -1;
                //    //transform.position = pos2;    // GUIUtility.GUIToScreenPoint(positionGui);

                SpawnPoint.getSpawnPointAtRandomInsideBoundsExcludeHud();


                //raycast example, originally from Physics.OverlapSphere, in TB burst ability
                //if (enemy != null) {
                //    // test if enemy is exposed to blast, or behind cover:
                //    RaycastHit hit;
                //    bool exposed = false;


                //    if (Physics.Raycast(transform.position, enemy.transform.position - transform.position, out hit)) {
                //        if (hit.collider == enemy.collider) { exposed = true; };
                //        //exposed = (hit.collider = enemy.collider);
                //    }

                //    Logger.logPlayer("enemy will be hit by burst tag: " + enemy.tag + ".  exposed? : " + exposed);

                //    if (exposed) {
                //        // Damage Enemy! with a linear falloff of damage amount
                //        //float proximity = (location - enemy.transform.position).magnitude;
                //        //float effect = 1 - (proximity / radius);
                //        //enemy.takeDamage(Mathf.RoundToInt(damage * effect));
                //        enemy.takeDamage(Mathf.RoundToInt(BURST_DAMAGE));
                //    }
                //}
            }
	}
}

