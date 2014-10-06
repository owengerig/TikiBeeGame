using UnityEngine;
using System.Collections;

namespace TikiBeeGame {
    public class HudController : MonoBehaviour {

        public GUIStyle menuButtonStyle;

        public Rect mainMenuButtonRect = new Rect(300, 90, 220, 60);

        public Rect statModButtonRect = new Rect(10, 10, 180, 20);

        public Rect startGameButtonRect = new Rect(10, 30, 180, 20);

        virtual public void runParticle(ParticleSystem ps) {
            ps.transform.position = transform.position;
            ps.renderer.sortingLayerName = "Particles";
            ps.renderer.sortingOrder = 0;
            ps.Play();
        }
        virtual public void runEmitter(ParticleEmitter pe) {
            pe.transform.position = transform.position;
            pe.renderer.sortingLayerName = "Particles";
            pe.renderer.sortingOrder = 0;
            pe.emit = true;
        }
    }
}
